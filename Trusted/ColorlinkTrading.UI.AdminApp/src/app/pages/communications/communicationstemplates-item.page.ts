import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxTextAreaModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxResponsiveBoxModule, DxButtonModule, DxFormModule, DxFormComponent, DxFileUploaderModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'communicationstemplates-item',
  templateUrl: './communicationstemplates-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css', './communicationstemplates-item.page.css']
})

export class CommTemplatesItemPage {
  currentRecordId: number = 0;
  BrandNamesList: any = [];
  CommunicationTypeList: any = [];
  HTMLRender: string = "HTML RENDER TAtenda";
  focustItem: any = {
    "BrandName": null,
    "CommunicationTypeId": null,
    "IsActive": null,
    "CommunicationTemplateId": null,
    "CommunicationTemplateName": null,
    "CommunicationType": null,
    "CommunicationType1": null,
    "CommunicationTemplateReference": null,
    "MailTemplateContent": null,
    "MailAttachmentFileNames": null,
    "SMSTemplateContent": null,
    "InAppMessageTemplateContent": null,
    "InAppMessageImageContent": null,
    "InAppMessageImageContentThumbnail": null
  };
  EmailRow: any = {};
  EmailSubject: string = "";
  EmailFrom: string = "";
  EmailDate: string = "";
  EmailsList: any = {};
  NoOfEmails: number = 0;
  ImapUid: number = 0;

  constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Communication Templates");
    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
    this.GetEmails();
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
      this.apiProvider.CommunicationTemplateItem_Get(this.currentRecordId).then(
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
  uploadSMSFile($event) {
    let files = $event.target.files;
    if (files.length > 0) {
      this.apiProvider.FileUsingIdentifier_Upload(files[0], "Communications").then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            this.focustItem.SMSTemplateContent = result.Feedback;
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }


  GetBrandNames() {
    this.apiProvider.CommunicationTemplateBrandName_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.BrandNamesList = result.data;
          this.GetCommunicationTypes();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }


  GetCommunicationTypes() {
    this.apiProvider.CommunicationTypes_Get("SchoolDays", true).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.CommunicationTypeList = result.CommunicationTypes;
          this.GetItemData();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }
  GridRowSelected($event) {
    this.GetHTMLBody($event.selectedRowKeys[0].ImapUid);
    this.ImapUid = $event.selectedRowKeys[0].ImapUid;
    this.EmailSubject = $event.selectedRowKeys[0].EmailSubject;
    this.EmailDate = $event.selectedRowKeys[0].EmailDate;
    this.EmailFrom = $event.selectedRowKeys[0].FromName;
  }

  GetHTMLBody($ImapUid) {
    this.apiProvider.HTMLBody_Get($ImapUid).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.HTMLRender = result.HTMLBody;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  DeleteEmail() {
    if (this.ImapUid != 0) {
      this.apiProvider.Email_Delete(this.ImapUid).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          if (result.EmailDeleted) {
            appGlobals.ShowToastNotification("Email Successfully Deleted", "Success");
            this.ImapUid = 0;
            this.GetEmails();
          } else {
            appGlobals.ShowToastNotification("Email Not Deleted", "Error");
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  GetEmails() {
    this.apiProvider.Emails_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.EmailsList = result.Emails;
          this.NoOfEmails = result.NumberOfEmails;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  CancelSave() {
    this.routeControl.navigate(["communicationstemplates-list"]);
  }

  SaveRecord($event) {
    // this.apiProvider.CommunicationTemplate_Write(this.focustItem).then(
    //   (result: any) => {
    //     if (result.HasError) {
    //       throw "Data Load Error: " + result.Feedback;
    //     }
    //     else {
    //       appGlobals.ShowToastNotification(result.Feedback, "Success");
    //       this.routeControl.navigate(["communicationstemplates-list"]);

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
