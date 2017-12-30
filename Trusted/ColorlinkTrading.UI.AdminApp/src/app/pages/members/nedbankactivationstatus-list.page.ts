import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIMembersProvider } from './../../providers/api.members.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'nedbankactivationstatus-list',
  templateUrl: './nedbankactivationstatus-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class NedbankActivationStatusListPage {

  showError: boolean = false;
  gridData: any = {};
  dataStore: any = {};
  SearchDateFrom = new Date(2010, 1, 1);
  SearchDateTo = new Date();
  totalCount: number = 0;
  SearchText: string = "";
  SearchPeriod: string = "ThisMonth";

  OrderField: string = "CardNumber";
  OrderDirection: string = "DESC";

  constructor(private routeControl: Router, private apiProvider: APIMembersProvider, private apiUtility: APIUtilityProvider) {
    appGlobals.SetActivePageTitle("Nedbank Activation Status");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngAfterContentInit() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "CardNumber";
        var orderDirection = (loadOptions.sort && loadOptions.sort[0].desc) ? "DESC" : "ASC";
        var pageNumber = (loadOptions.skip / loadOptions.take) + 1;
        var pageSize = loadOptions.take;
        var filter = (loadOptions.searchValue == null ? "" : loadOptions.searchValue);

        this.SearchText = filter;
        this.OrderField = orderField;
        this.OrderDirection = orderDirection;

        return that.apiUtility.UtilityProvider_GetPeriodDates(that.SearchPeriod).then(
          (result: any) => {
            //grab the dates from the result
            that.SearchDateFrom = result.StartDateString;
            that.SearchDateTo = result.EndDateString;
            //filter the data
            return that.apiProvider.NedbankActivationStatus_Search(pageSize, pageNumber, orderField, orderDirection,
              filter, that.SearchDateFrom, that.SearchDateTo).then(
              (result: any) => {
                if (result.HasError) {
                  throw "Data Load Error: " + result.Feedback;
                }
                that.totalCount = result.NumberOfRecords;
                return {
                  data: result.NedbankActivationStatus,
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
        location: 'before',
        widget: 'dxButton',
        options: {
          hint: 'Export to Excel',
          icon: 'assets/excelicon.png',
          onClick: this.exportToExcel.bind(this)
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
      {
        location: 'after',
        widget: 'dxTextBox',
        options: {
          width: 400,
          mode: 'search',
          placeholder: 'Search ...',
          onValueChanged: this.TextFilterChanged.bind(this)
        }
      });
  }

  exportToExcel() {
    appGlobals.ShowGlobalLoader();
    this.apiProvider.NedbankActivationStatus_Export(this.OrderField, this.OrderDirection, this.SearchText, this.SearchDateFrom, this.SearchDateTo).then(
      (result: any) => {
        appGlobals.HideGlobalLoader();
        if (result.HasError) {
          appGlobals.ShowGlobalModal("Error Retrieving Data", result.Feedback, "warning");
        }
        else {
          this.apiUtility.UtiltyProvider_DownloadMedia(result.MediaGUID);
        }
      },
      (error) => {
        appGlobals.HideGlobalLoader();
        appGlobals.ShowGlobalModal("Error Retrieving Data", "An unknown error occurred retrieving your data", "warning");
      });

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
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, true, true, true, true, false);
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, true, true, true, true);
  }
}