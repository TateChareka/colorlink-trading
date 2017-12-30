import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';
import { SafeResourceUrl, DomSanitizer } from '@angular/platform-browser';

import {
  DxDataGridModule, DxTextAreaModule, DxDateBoxModule, DxLoadPanelModule,
  DxCheckBoxModule, DxTextBoxModule, DxResponsiveBoxModule, DxPopupModule,
  DxButtonModule, DxFormModule, DxFormComponent, DxFileUploaderModule, DxFilterBuilderModule, DxButtonComponent,
  DxValidationGroupComponent, DxValidatorComponent, DxValidationSummaryComponent
} from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'communicationsmessages-item',
  templateUrl: './communicationsmessages-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css', './communicationsmessages-item.page.css']
})

export class CommMessagesItemPage {
  CurrentDate: Date = new Date();
  currentRecordId: number = null;
  loadingVisible = false;
  CommunicationMessageAttachmentId: number = null;
  CommunicationTypeList: any = [];
  StatementDatesList: any = [];
  MessageTypeList: any = [];
  EndUserCommunicationCategoryList: any = [];
  TypeMessageToSendList: any = [];
  CommunicationTemplatesList: any = [];
  MatchingFilteredRecipientCount: string = null;
  btnState: boolean = false;
  popupMailDeleteVisible = false;
  ImapUid: number = null;
  SelectedCommunicationType: string = "";

  mailContentSRC: SafeResourceUrl = null;
  hasContent: boolean = false;

  stringFilterOperators: any = ['=', '<>', 'isblank', 'isnotblank', 'startswith'];
  fields: any = [
    {
      caption: "Registration Source",
      dataField: "RegistrationSource",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "Gender",
      dataField: "Gender",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "Registration Date",
      dataField: "RegistrationDate",
      dataType: "date",
      format: "dd MMMM yyyy"
    },
    {
      caption: "Dischem Activated",
      dataField: "IsDischemActivated",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "Average Spend Partner Transactions Per Month",
      dataField: "AverageSpendPartnerTransactionsPerMonth",
      dataType: "number",
      format: "numeric"
    },
    {
      caption: "Main Dischem Spend Store",
      dataField: "MainDischemSpendStore",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "Dischem Registration Store",
      dataField: "DischemRegistrationOutlet",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "Has Address",
      dataField: "HasAddress",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "EDU Number",
      dataField: "CardNumber",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "App Version Installed",
      dataField: "AppVersionInstalled",
      dataType: "string",
      format: "string",
      filterOperations: this.stringFilterOperators
    },
    {
      caption: "First Accelerator Tool Transaction Date",
      dataField: "FirstAcceleratorToolTransactionDate",
      dataType: "date",
      format: "dd MMMM yyyy"
    },
    {
      caption: "Last Accelerator Tool Transaction Date",
      dataField: "LastAcceleratorToolTransactionDate",
      dataType: "date",
      format: "dd MMMM yyyy"
    },
    {
      caption: "Beneficiary Count",
      dataField: "BeneficiaryCount",
      dataType: "number",
      format: "numeric"
    },
    {
      caption: "Age in Years",
      dataField: "AgeInYears",
      dataType: "number",
      format: "numeric"
    },
    {
      caption: "Last Site Activity Date",
      dataField: "LastSiteActivityDate",
      dataType: "date",
      format: "dd MMMM yyyy"
    }
  ];
  selectedCategory: string = "";
  //mailchimp properties
  EmailsList: any = [];
  NoOfEmails: number = 0;


  communicationMessage: any = {
    "CommunicationMessageId": null,
    "MsgBody": "",
    "MessageType": "",
    "MessageDescription": "",
    "MessageSubject": "",
    "CommunicationTypeId": null,
    "CommunicationTemplateId": null,
    "ImapUid": null,
    "MessageFilter": "",
    "MessageFilterUI": "",
    "SMSTemplateContent": "",
    "IsDeleted": false,
    "StatementDateToAttach": null,
    "EmailLinks": []
  };

  constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute,
    private sanitizer: DomSanitizer) {
    appGlobals.SetActivePageTitle("Communication Messages");
    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
    this.getCommunicationTypes();
    this.getMessageTypes();
    this.getCommunicationTemplates();
    this.getStatementDates();
    this.getEmails(false);
    this.mailContentSRC = this.sanitizer.bypassSecurityTrustResourceUrl(appGlobals.WebServiceURL +
      '/CommunicationsMessageService/GetEmailHTML?type=template&identifier=0');
  }

  showEmailsLoading: boolean = false;
  getEmails(showToast: boolean) {
    this.showEmailsLoading = true;
    this.apiProvider.Emails_Get().then(
      (result: any) => {
        this.showEmailsLoading = false;
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.EmailsList = result.Emails;
          this.NoOfEmails = result.NumberOfEmails;
          if (showToast) {
            appGlobals.ShowToastNotification("Emails reloaded from MailChimp mailbox", "success");
          }
        }
      },
      (error) => {
        this.showEmailsLoading = false;
        throw "Data Load Error";
      });
  }

  fromDisplay(item: any): string {
    if (item.FromName == null || item.FromName.trim() == '') {
      return item.FromAddress;
    }
    return item.FromName + ' [' + item.FromAddress + ']';
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let ref = params['ref'];
      this.currentRecordId = null;
      if (ref) {
        this.currentRecordId = parseInt(ref);
      }
      this.initData();
    });
  }

  initData() {
    this.getItemData();
  }

  getCommunicationTypes() {
    this.apiProvider.CommunicationTypes_Get("SchoolDays", false).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.CommunicationTypeList = result.CommunicationTypes;
          this.getMessageTypes();
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  getItemData() {
    if (this.currentRecordId != null) {
      this.apiProvider.CommunicationMessageItem_Get(this.currentRecordId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            if (result.DateQueuedToSend != null) {
              result.DateQueuedToSend = this.formatDateColumn(result.DateQueuedToSend);
            }
            result.StatementDateToAttach = this.formatDateColumn(result.StatementDateToAttach);
            //transform the operators in the array from arrays into strings
            if (result.MessageFilterUI != null) {
              if (result.MessageFilterUI != "") {
                for (var i = 0; i < result.MessageFilterUI.length; i++) {
                  if (result.MessageFilterUI[i].length == 1) {
                    result.MessageFilterUI[i] = result.MessageFilterUI[i][0];
                  }
                }
              }
            }
            this.communicationMessage = result;
            this.hasContent = true;
            this.mailContentSRC = this.sanitizer.bypassSecurityTrustResourceUrl(appGlobals.WebServiceURL +
              '/CommunicationsMessageService/GetEmailHTML?type=message&identifier=' + this.currentRecordId.toString());
            this.recipientCount();
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  recipientCount() {
    var res = null;
    if (this.communicationMessage.MessageFilterUI == null || this.communicationMessage.MessageFilterUI.length == 0) {
    } else {
      var res = appGlobals.ConvertFilterBuilderObjectModel(this.communicationMessage.MessageFilterUI);
    }
    this.MatchingFilteredRecipientCount = "Counting matching recipients ... ";
    this.apiProvider.CommunicationsFilterDataCount_Get(res).then(
      (result: any) => {
        if (result.HasError) {
          this.MatchingFilteredRecipientCount = "Error counting recipients";
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.MatchingFilteredRecipientCount = result.filterCount;
        }
      },
      (error) => {
        this.MatchingFilteredRecipientCount = "Error counting recipients";
        throw "Data Load Error";
      });
  }

  getMessageTypes() {
    this.apiProvider.MessageType_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.MessageTypeList = result.MessagesTypes;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  getStatementDates() {
    this.apiProvider.StatementDates_Get("SchoolDays").then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.StatementDatesList = result.StatementDates;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  refreshEMail() {
    this.EmailsList = [];
    this.getEmails(true);
  }

  selectSmsContent() {
    this.communicationMessage.CommunicationTemplateId = null;
    this.communicationMessage.ImapUid = null;
  }

  selectTemplate(templateItem) {
    this.communicationMessage.CommunicationTemplateId = templateItem.CommunicationTemplateId;
    this.communicationMessage.ImapUid = null;
    this.communicationMessage.SMSTemplateContent = null;
    this.hasContent = true;
    this.mailContentSRC = this.sanitizer.bypassSecurityTrustResourceUrl(appGlobals.WebServiceURL +
      '/CommunicationsMessageService/GetEmailHTML?type=template&identifier=' + templateItem.CommunicationTemplateId.toString());
    //update the links
    this.apiProvider.CommunicationMessage_GetTemplateEmailLinks(templateItem.CommunicationTemplateId).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          console.log(result);
          this.communicationMessage.EmailLinks = result.EmailLinks;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  selectMailChimpItem(mailchimpItem) {
    this.communicationMessage.CommunicationTemplateId = null;
    this.communicationMessage.ImapUid = mailchimpItem.ImapUid;
    this.communicationMessage.SMSTemplateContent = null;
    this.hasContent = true;
    this.mailContentSRC = this.sanitizer.bypassSecurityTrustResourceUrl(appGlobals.WebServiceURL +
      '/CommunicationsMessageService/GetEmailHTML?type=imap&identifier=' + mailchimpItem.ImapUid.toString());
    //update the links
    this.apiProvider.CommunicationMessage_GetImapEmailLinks(mailchimpItem.ImapUid).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          console.log(result);
          this.communicationMessage.EmailLinks = result.EmailLinks;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  deleteMailChimpItem(mailchimpItem) {
    this.ImapUid = mailchimpItem.ImapUid;
    this.popupMailDeleteVisible = true;
  }

  deleteMailChimpItemYes() {
    if (this.ImapUid != null) {
      this.apiProvider.Email_Delete(this.ImapUid).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            if (result.EmailDeleted) {
              this.popupMailDeleteVisible = false;
              this.ImapUid = null;
              this.EmailsList = [];
              this.getEmails(true);
              appGlobals.ShowToastNotification("Email Deleted", "Success");
            } else {
              appGlobals.ShowToastNotification("Email Not Deleted", "Error");
            }
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  deleteMailChimpItemNo() {
    this.popupMailDeleteVisible = false;
  }

  getCommunicationTemplates() {
    this.apiProvider.CommunicationTemplates_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          this.CommunicationTemplatesList = result.Templates;
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  backToGrid() {
    this.routeControl.navigate(["communicationsmessages-list"]);
  }

  writingMessage: boolean = false;
  saveRecord(e) {
    if (this.writingMessage) {
      return;
    }
    this.writingMessage = true;
    this.communicationMessage.MessageFilter = appGlobals.ConvertFilterBuilderObjectModel(this.communicationMessage.MessageFilterUI);
    console.log(this.communicationMessage);
    this.apiProvider.CommunicationMessages_Write(this.communicationMessage).then(
      (result: any) => {
        this.writingMessage = false;
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        else {
          appGlobals.ShowToastNotification(result.Feedback, "Success");
          this.routeControl.navigate(["communicationsmessages-list"]);
        }
      },
      (error) => {
        this.writingMessage = false;
        throw "Data Load Error";
      });
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo, false, true, true, true, false);
  }

  onShown() {
    setTimeout(() => {
      this.loadingVisible = false;
    }, 4000);
  }
  showLoadPanel() {
    this.loadingVisible = true;
  }

  changeBtnState() {
    this.btnState = true;
  }

  /* validation rules */
  validationRules = {
    messageDescription: [
      { type: 'required', message: 'Message Description is required.' }
    ],
    communicationCategory: [
      { type: 'required', message: 'Communication Category is required.' }
    ],
    messageType: [
      { type: 'required', message: 'Type of Message to Send is required.' }
    ],
    messageSubject: [
      { type: 'required', message: 'Message Subject is required.' }
    ],
    emailContent: [
      { type: 'required', message: 'Please select a template or an email from the MailBox.' }
    ],
    emailLinks: [
      { type: 'required', message: 'Please indicate values for ALL email links.' }
    ],
    smsContent: [
      { type: 'required', message: 'Please enter SMS content.' }
    ]
  };

  emailContentIdentifier() {
    if (this.communicationMessage.MessageType != 'Email') {
      return 'irrelevant';
    }
    if (this.hasContent) {
      return 'irrelevant';
    }
    if (this.communicationMessage.CommunicationTemplateId == null && this.communicationMessage.ImapUid == null) {
      return '';
    }
    return 'irrelevant';
  }

  emailLinksIdentifier() {
    if (this.communicationMessage.MessageType != 'Email') {
      return 'irrelevant';
    }
    for (var i = 0; i < this.communicationMessage.EmailLinks.length; i++) {
      if (this.communicationMessage.EmailLinks[i].EmailLinkReplacement == null) {
        return "";
      }
      if (this.communicationMessage.EmailLinks[i].EmailLinkReplacement.trim() == "") {
        return "";
      }
    }
    return 'irrelevant';
  }

  smsContentIdentifier() {
    if (this.communicationMessage.MessageType != 'SMS') {
      return 'irrelevant';
    }
    if (this.communicationMessage.SMSTemplateContent == null || this.communicationMessage.SMSTemplateContent.trim() == '') {
      return '';
    }
    return 'irrelevant';
  }

  emailBorderStyle() {
    if (this.emailContentIdentifier() == '') {
      return "1px solid red";
    }
    return "none";
  }

  smsBorderStyle() {
    if (this.smsContentIdentifier() == '') {
      return "1px solid red";
    }
    return "none";
  }
}
