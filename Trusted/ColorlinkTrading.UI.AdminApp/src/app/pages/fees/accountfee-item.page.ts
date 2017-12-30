import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIFeesProvider } from './../../providers/api.fees.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxFormModule, DxFormComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'accountfee-item',
  templateUrl: './accountfee-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class AccountFeeItemPage {
  CurrentDate = new Date().toDateString();
  minDate: Date = new Date();
  currentRecordId: number = 0;
  FeeModelsList: any = [];
  FeeMonthsList: any = [];
  focustItem: any = {
    "AccountFeesID": null,
    "FeeMonth": "",
    "FeeModel": "",
    "FeeModelId": "",
    "FeeProcessDate": new Date(),
    "FeeTransactionDate": new Date()
  };

  constructor(private routeControl: Router, private apiProvider: APIFeesProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Account Fee");
    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let ref = params['ref'];
      this.currentRecordId = 0;
      if (ref) {
        this.currentRecordId = parseInt(ref);
      }
      this.initData();
    });
  }

  initData() {
    this.GetFeeMonths();
  }

  GetItemData() {
    if (this.currentRecordId != 0) {
      this.apiProvider.AccountFeeItem_Get(this.currentRecordId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            result.FeeProcessDate = this.formatDateColumn(result.FeeProcessDate);
            result.FeeTransactionDate = this.formatDateColumn(result.FeeTransactionDate);
            this.focustItem = result;
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  GetFeeModels() {
    this.apiProvider.AccountFeeModels_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.FeeModelsList = result.AccounFeesModel;
          this.GetItemData();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  GetFeeMonths() {
    this.apiProvider.AccountFeeMonths_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.FeeMonthsList = result.data;
          this.GetFeeModels();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  CancelSave() {
    this.routeControl.navigate(["accountfee-list"]);
  }

  SaveRecord($event) {
    this.apiProvider.AccountFee_Write(this.focustItem).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          appGlobals.ShowToastNotification(result.Feedback, "Success");
          this.routeControl.navigate(["accountfee-list"]);
          $event.preventDefault();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo, false, true, true, true, false);
  }

}