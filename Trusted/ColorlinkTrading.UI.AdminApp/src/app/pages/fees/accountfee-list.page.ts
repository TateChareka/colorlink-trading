import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIFeesProvider } from './../../providers/api.fees.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'accountfee-list',
  templateUrl: './accountfee-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class AccountFeeListPage {

  showError: boolean = false;
  gridData: any = {};
  dataStore: any = {};
  SearchDateFrom = new Date(2010, 1, 1);
  SearchDateTo = new Date();
  totalCount: number = 0;
  SearchText: string = "";
  SearchPeriod: string = "ThisQuarter";
  OrderField: string = "FeeTransactionDate";
  OrderDirection: string = "DESC";

  ActionRow: any = {};
  DeleteState: boolean = false;

  constructor(private routeControl: Router, private apiProvider: APIFeesProvider, private apiUtility: APIUtilityProvider) {
    appGlobals.SetActivePageTitle("Process Account Fees");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngAfterContentInit() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "FeeTransactionDate";
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
            return that.apiProvider.ProcessAccountFees_Get(pageSize, pageNumber, orderField, orderDirection,
              filter, that.SearchDateFrom, that.SearchDateTo).then(
              (result: any) => {
                if (result.HasError) {
                  throw "Data Load Error: " + result.Feedback;
                }
                that.totalCount = result.NumberOfRecords;
                return {
                  data: result.AccounFees,
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
      // {
      //   location: 'before',
      //   widget: 'dxButton',
      //   options: {
      //     hint: 'Export to Excel',
      //     icon: 'assets/excelicon.png',
      //     onClick: this.exportToExcel.bind(this)
      //   }
      // },
      {
        location: 'before',
        widget: 'dxButton',
        options: {
          hint: 'Schedule Account Fee',
          text: 'Schedule Account Fee',
          type: 'default',
          onClick: this.ScheduleAccountFee.bind(this)
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
      });
  }

  exportToExcel() {

  }

  EditAccountFees() {
    this.routeControl.navigate(["accountfee-item", { "ref": this.ActionRow.AccountFeesID }]);
  }

  DeleteAccountFees() {
    this.apiProvider.AccountFee_Delete(this.ActionRow.AccountFeesID).then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        appGlobals.ShowToastNotification(result.Feedback, "Success");
        this.ngAfterContentInit();
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  ScheduleAccountFee() {
    this.routeControl.navigate(["accountfee-item"]);
  }

  ViewAccountFees() {

  }

  DateFilterChanged($event) {
    this.SearchPeriod = $event.value;
    this.dataStore.load();
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, true, true, true, true);
  }
  formatMonthDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, false, true, true, true);
  }
}