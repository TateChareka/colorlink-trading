import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIMembersProvider } from './../../providers/api.members.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxFormModule, DxFormComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'acceleratorlistings-item',
  templateUrl: './acceleratorlistings-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class AcceleratorItemListPage {
  currentRecordId: number = 0;
  AcceleratorStatusList: any = [];
  focustItem: any = {
    "AcceleratorId": null,
    "CardNumber": "",
    "FullName": "",
    "Email": "",
    "MobileNumber": "",
    "IdentificationNumber": "",
    "PaymentMethodType": "",
    "ZARAmount": "",
    "BankName": "",
    "BranchName": "",
    "BranchNumber": "",
    "AccountNumber": "",
    "AccountHolderName": "",
    "PaymentDay": "",
    "AcceleratorStatus": "",
    "AccountType": "",
    "CreatedDate": new Date(),
    "UpdatedDate": new Date(),
    "CreatedByUserName": "",
    "UpdatedByUserName": ""
  };

  constructor(private routeControl: Router, private apiProvider: APIMembersProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Accelerator Listings");
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
    this.GetAcceleratorStatus();
  }

  GetAcceleratorStatus() {
    this.apiProvider.AcceleratorStatus_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.AcceleratorStatusList = result.data;
          this.GetItemData();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  GetItemData() {
    if (this.currentRecordId != 0) {
      this.apiProvider.AcceleratorItem_Get(this.currentRecordId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            this.focustItem = result;
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  CancelSave() {
    this.routeControl.navigate(["acceleratorlistings-list"]);
  }
  SaveRecord($event) {
    this.apiProvider.AcceleratorStatus_Write(this.focustItem).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          appGlobals.ShowToastNotification(result.Feedback, "Success");
          this.routeControl.navigate(["acceleratorlistings-list"]);
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