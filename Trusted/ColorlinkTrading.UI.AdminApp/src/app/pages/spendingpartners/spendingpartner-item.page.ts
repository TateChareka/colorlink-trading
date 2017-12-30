import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APISpendingPartnerProvider } from './../../providers/api.spendingpartners.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxTextAreaModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxResponsiveBoxModule, DxButtonModule, DxFormModule, DxFormComponent, DxFileUploaderModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'spendingpartner-item',
  templateUrl: './spendingpartner-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css', './spendingpartner-item.page.css']
})

export class SpendingPartnerItemPage {
  currentRecordId: number = 0;
  BrandNamesList: any = [];
  CommunicationTypeList: any = [];
  HTMLRender: string = "HTML RENDER TAtenda";
  focustItem: any = {

  };
  EmailsList: any = {};
  NoOfEmails: number = 0;
  ImapUid: number = 0;

  constructor(private routeControl: Router, private apiProvider: APISpendingPartnerProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Spending Partner");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
    // this.GetEmails();
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
    // if (this.currentRecordId != 0) {
    //   this.apiProvider.CommunicationTemplateItem_Get(this.currentRecordId).then(
    //     (result: any) => {
    //       if (result.HasError) {
    //         throw "Data Load Error: " + result.Feedback;
    //       }
    //       else {
    //         this.focustItem = result;
    //       }
    //     },
    //     (error) => {
    //       throw "Data Load Error";
    //     });
    // }
  }

  GetBrandNames() {
    // this.apiProvider.CommunicationTemplateBrandName_Get().then(
    //   (result: any) => {
    //     if (result.HasError) {
    //       throw "Data Load Error: " + result.Feedback;
    //     }
    //     else {
    //       this.BrandNamesList = result.data;
    //       this.GetCommunicationTypes();
    //     }
    //   },
    //   (error) => {
    //     throw "Data Load Error";
    //   });
  }



  GridRowSelected($event) {
    //this.GetHTMLBody($event.selectedRowKeys[0].ImapUid);
    this.ImapUid = $event.selectedRowKeys[0].ImapUid;
  }



  CancelSave() {
    this.routeControl.navigate(["spendingpartner-list"]);
  }

  SaveRecord($event) {
    // this.apiProvider.CommunicationTemplate_Write(this.focustItem).then(
    //   (result: any) => {
    //     if (result.HasError) {
    //       throw "Data Load Error: " + result.Feedback;
    //     }
    //     else {
    //       appGlobals.ShowToastNotification(result.Feedback, "Success");
    //       this.routeControl.navigate(["spendingpartner-list"]);

    //     }
    //   },
    //   (error) => {
    //     throw "Data Load Error";
    //   });
    $event.preventDefault();
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo, false, true, true, true, false);
  }

}
