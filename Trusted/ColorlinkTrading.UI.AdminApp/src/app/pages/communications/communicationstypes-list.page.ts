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
  selector: 'communicationstypes-list',
  templateUrl: './communicationstypes-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class CommTypesListPage {
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
    appGlobals.SetActivePageTitle("Communication Types");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngAfterContentInit() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "CommunicationTypeId";
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
            return that.apiProvider.CommunicationType_List(pageSize, pageNumber, orderField, orderDirection, that.BrandName,
              that.SearchDateFrom, that.SearchDateTo).then(
              (result: any) => {
                if (result.HasError) {
                  throw "Data Load Error: " + result.Feedback;
                }
                that.totalCount = result.NumberOfRecords;
                return {
                  data: result.Types,
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
    e.toolbarOptions.items.unshift(
      {
        location: 'before',
        template: 'totalItemCount'
      },
      {
        location: 'before',
        widget: 'dxButton',
        options: {
          hint: 'Add Communication Type',
          text: 'Add Communication Type',
          type: 'default',
          onClick: this.AddCommunicationType.bind(this)
        }
      },
      {
        location: 'after',
        template: 'periodLabel'
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

  EditCommunicationType() {
    this.routeControl.navigate(["communicationstypes-item", { "ref": this.ActionRow.CommunicationTypeId }]);
  }

  AddCommunicationType() {
    this.routeControl.navigate(["communicationstypes-item"]);
  }

  deleteCommunicationType() {
    this.popupMailDeleteVisible = true;
  }

  deleteCommunicationTypeYes() {
    if (this.ActionRow.CommunicationTypeId != 0) {
      this.apiProvider.CommunicationType_Delete(this.ActionRow.CommunicationTypeId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          appGlobals.ShowToastNotification(result.Feedback, "Success");
          this.ngAfterContentInit();
          this.popupMailDeleteVisible = false;
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  deleteCommunicationTypeNo() {
    this.popupMailDeleteVisible = false;
  }
}