import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxTextAreaModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'communicationsmessages-list',
  templateUrl: './communicationsmessages-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class CommMessagesListPage {
  confirmationText: string = "";
  btnQueueNow: boolean = false;
  btnDelete: boolean = false;
  btnSendMulti: boolean = false;
  popupMailDeleteVisible = false;
  currentDate: Date = new Date();
  showError: boolean = false;
  gridData: any = {};
  dataStore: any = {};
  SearchDateFrom = new Date(2010, 1, 1);
  SearchDateTo = new Date();
  totalCount: number = 0;
  SearchText: string = "";
  SearchPeriod: string = "ThisMonth";
  Multirecipients: string = "";
  ActionRow: any = {};


  constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider) {
    appGlobals.SetActivePageTitle("Communication Messages");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngAfterContentInit() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "CommunicationMessageId";
        var orderDirection = (loadOptions.sort && loadOptions.sort[0].desc) ? "DESC" : "ASC";
        var pageNumber = (loadOptions.skip / loadOptions.take) + 1;
        var pageSize = loadOptions.take;
        var filter = (loadOptions.searchValue == null ? "" : loadOptions.searchValue);

        return that.apiUtility.UtilityProvider_GetPeriodDates(that.SearchPeriod).then(
          (result: any) => {
            //grab the dates from the result
            that.SearchDateFrom = result.StartDateString;
            that.SearchDateTo = result.EndDateString;
            //filter the data
            return that.apiProvider.CommunicationMessages_List(pageSize, pageNumber, orderField, orderDirection,
              that.SearchDateFrom, that.SearchDateTo).then(
              (result: any) => {
                if (result.HasError) {
                  throw "Data Load Error: " + result.Feedback;
                }
                that.totalCount = result.NumberOfRecords;
                return {
                  data: result.Messages,
                  totalCount: result.NumberOfRecords
                };
              },
              (error) => {
                throw "Data Load Error";
              });

          },
          (error) => {
            throw "Data Load Error";
          });
      }
    });
    this.gridData = this.dataStore;
  }

  onToolbarPreparing(e) {
    e.toolbarOptions.items.unshift({
      location: 'before',
      template: 'totalItemCount'
    },
      {
        location: 'after',
        template: 'periodLabel'
      },
      {
        location: 'before',
        widget: 'dxButton',
        options: {
          hint: 'Add Communication Message',
          text: 'Add Communication Message',
          type: 'default',
          onClick: this.AddCommunicationMessage.bind(this)
        }
      },
      {
        location: 'after',
        widget: 'dxSelectBox',
        options: {
          width: 200,
          items: appGlobals.GetStandardPeriodDropDownItems(),
          displayExpr: 'text',
          valueExpr: 'value',
          value: this.SearchPeriod,
          onValueChanged: this.DateFilterChanged.bind(this)
        }
      },
    );
  }

  DateFilterChanged($event) {
    this.SearchPeriod = $event.value;
    this.dataStore.load();
  }
  TextFilterChanged($event) {
    this.SearchText = $event.value;
    this.dataStore.searchValue(this.SearchText);
    this.dataStore.load();
  }

  formatDateTimeColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, true, true, true, true, true);
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, true, true, true, true);
  }

  formatFullDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, false, true, true, true);
  }

  EditCommMessage() {
    this.routeControl.navigate(["communicationsmessages-item", { "ref": this.ActionRow.CommunicationMessageId }]);
  }

  AddCommunicationMessage() {
    this.routeControl.navigate(["communicationsmessages-item"]);
  }

  SendMeACopy() {
    this.apiProvider.CommunicationsMessages_SendTest(this.ActionRow.CommunicationMessageId).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        } else {
          appGlobals.ShowToastNotification(result.Feedback, "Success");
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }




  CopyAndEdit() {
    this.apiProvider.CommunicationsMessages_CopyEdit(this.ActionRow.CommunicationMessageId).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        } else {
          this.routeControl.navigate(["communicationsmessages-item", { "ref": result.CommunicationMessageId }]);
        }
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  deleteCommunicationMessage() {
    this.confirmationText = "Are you sure you want to delete this Commmunication message?";
    this.btnQueueNow = false;
    this.btnSendMulti = false
    this.btnDelete = true;
    this.popupMailDeleteVisible = true;
  }

  deleteCommunicationMessageYes() {
    if (this.ActionRow.CommunicationMessageId != 0) {
      var that = this;
      this.apiProvider.CommunicationsMessages_RemoveMessage(this.ActionRow.CommunicationMessageId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            that.ngAfterContentInit();
            this.popupMailDeleteVisible = false;
            appGlobals.ShowToastNotification(result.Feedback, "Success");            
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  queueNow() {
    this.confirmationText = "Are you sure you want to Queue this commmunication message Now?";
    this.btnQueueNow = true;
    this.btnSendMulti = false
    this.btnDelete = false;
    this.popupMailDeleteVisible = true;
  }

  queueNowYes() {
    if (this.ActionRow.CommunicationMessageId != 0) {
      var that = this;
      this.apiProvider.CommunicationsMessages_QueueMessage(this.ActionRow.CommunicationMessageId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            that.ngAfterContentInit();
            this.popupMailDeleteVisible = false;
            appGlobals.ShowToastNotification(result.Feedback, "Success");
            
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  confirmationMessageNo() {
    this.popupMailDeleteVisible = false;
  }

  sentMultiTest() {
    this.Multirecipients = "";
    if (this.ActionRow.MessageTypeDescription == "Email") {
      this.confirmationText = "Enter the Email addresses separated by (;)";
    } else {
      this.confirmationText = "Enter the Mobile Numbers separated by (;)";
    }
    this.btnQueueNow = false;
    this.btnSendMulti = true
    this.btnDelete = false;
    this.popupMailDeleteVisible = true;
  }

  SendACopyToMulti() {
    if (this.Multirecipients != "") {
      this.apiProvider.CommunicationsMessages_MultiSendTest(this.ActionRow.CommunicationMessageId, this.Multirecipients).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          } else {
            this.popupMailDeleteVisible = false;
            this.Multirecipients = "";
            appGlobals.ShowToastNotification(result.Feedback, "Success");
            
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

}