import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxFormModule, DxFormComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'communicationstypes-item',
  templateUrl: './communicationstypes-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class CommTypesItemPage {
  currentRecordId: number = 0;
  BrandNamesList: any = [];
  focustItem: any = {
    "CommunicationTypeId": null,
    "CommunicationType1": "",
    "BrandName": "",
    "FeeModelId": "",
    "IsActive": 0,
    "IsSystemCommunication": 0,
    "CanUnsubscribe": 0
  };


  constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Communication Types");

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
    this.GetBrandNames();
  }

  GetItemData() {
    if (this.currentRecordId != 0) {
      this.apiProvider.CommunicationTypeItem_Get(this.currentRecordId).then(
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

  GetBrandNames() {
    this.apiProvider.CommunicationTypesBrandName_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.BrandNamesList = result.data;
          this.GetItemData();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  CancelSave() {
    this.routeControl.navigate(["communicationstypes-list"]);
  }

  SaveRecord($event) {
    this.apiProvider.CommunicationType_Write(this.focustItem).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          appGlobals.ShowToastNotification(result.Feedback, "Success");
          this.routeControl.navigate(["communicationstypes-list"]);
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
