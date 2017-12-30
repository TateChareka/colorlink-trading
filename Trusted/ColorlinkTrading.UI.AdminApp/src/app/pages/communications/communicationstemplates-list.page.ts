import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'communicationstemplates-list',
  templateUrl: './communicationstemplates-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class CommTemplatesListPage {
  popupMailDeleteVisible = false;
  showError: boolean = false;
  gridData: any = {};
  dataStore: any = {};
  SearchDateFrom = new Date(2010, 1, 1);
  SearchDateTo = new Date();
  totalCount: number = 0;
  SearchText: string = "";
  BrandName: string = "";
  SearchPeriod: string = "All";
  ActionRow: any = {};

  constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider) {
    appGlobals.SetActivePageTitle("Communication Templates");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngAfterContentInit() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "CommunicationTemplateId";
        var orderDirection = (loadOptions.sort && loadOptions.sort[0].desc) ? "DESC" : "ASC";
        var pageNumber = (loadOptions.skip / loadOptions.take) + 1;
        var pageSize = loadOptions.take;
        var filter = (loadOptions.searchValue == null ? "" : loadOptions.searchValue);
        return that.apiUtility.UtilityProvider_GetPeriodDates(that.SearchPeriod).then(
          (result: any) => {
            that.SearchDateFrom = result.StartDateString;
            that.SearchDateTo = result.EndDateString;
            return that.apiProvider.CommunicationTemplate_List(pageSize, pageNumber, orderField, orderDirection, that.BrandName,
              that.SearchDateFrom, that.SearchDateTo).then(
              (result: any) => {
                if (result.HasError) {
                  throw "Data Load Error: " + result.Feedback;
                }
                that.totalCount = result.NumberOfRecords;
                return {
                  data: result.Templates,
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
          hint: 'Add Communication Template',
          text: 'Add Communication Template',
          type: 'default',
          onClick: this.AddCommunicationTemplate.bind(this)
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

  EditCommunicationTemplate() {
    this.routeControl.navigate(["communicationstemplates-item", { "ref": this.ActionRow.CommunicationTemplateId }]);
  }

  AddCommunicationTemplate() {
    this.routeControl.navigate(["communicationstemplates-item"]);
  }

  deleteCommunicationTemplate() {
    this.popupMailDeleteVisible = true;
  }

  deleteCommTemplateYes() {
    if (this.ActionRow.CommunicationTemplateId != 0) {
      this.apiProvider.CommunicationTemplate_Delete(this.ActionRow.CommunicationTemplateId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          } else {
            appGlobals.ShowToastNotification(result.Feedback, "Success");
            this.ngAfterContentInit();
            this.popupMailDeleteVisible = false;
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  deleteCommTemplateNo() {
    this.popupMailDeleteVisible = false;
  }

}