import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { APITransactionsProvider } from './../../providers/api.transactions.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxSelectBoxModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
    selector: 'transactionssummary-list',
    templateUrl: './transactionssummary-list.page.html',
    styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class TransactionsSummaryListPage {

    showError: boolean = false;
    gridData: any = {};
    dataStore: any = {};
    SearchDateFrom: Date = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
    SearchDateTo: Date = new Date();
    totalCount: number = 0;

    OrderField: string = "TransactionDateTime";
    OrderDirection: string = "ASC";
    transSummaryMonths: any = [];

    constructor(private routeControl: Router, private apiProvider: APITransactionsProvider, private apiUtility: APIUtilityProvider) {
        appGlobals.SetActivePageTitle("Monthly Transaction Summary");
        if (!appGlobals.checkSignInCache()) {
            this.routeControl.navigate(['/' + appGlobals.LandingPage]);
        }
        this.getTransactionSummaryMonths();
    }

    getTransactionSummaryMonths() {
        this.apiProvider.MonthlyTransactionSummaryMonths_Get().then(
            (result: any) => {
                if (result.HasError) {
                    throw "Data Load Error: " + result.Feedback;
                }
                this.transSummaryMonths = result.Months;
                this.SearchDateFrom = this.transSummaryMonths[0];
                this.SearchDateTo = this.transSummaryMonths[0];
            },
            (error) => {
                throw "Data Load Error";
            });
    }

    getDisplayValue(item) {
        return appGlobals.GetStringDateGenericFromJSON(item, false, false, true, true, true);
    }

    ngOnInit() {

    }

    ngAfterContentInit() {
        var that = this;
        this.dataStore = new DataSource({
            load: function (loadOptions) {
                var orderField = loadOptions.sort ? loadOptions.sort[0].selector : that.OrderField;
                var orderDirection = (loadOptions.sort && loadOptions.sort[0].desc) ? "ASC" : "DESC";
                var pageNumber = (loadOptions.skip / loadOptions.take) + 1;
                var pageSize = loadOptions.take;
                var filter = (loadOptions.searchValue == null ? "" : loadOptions.searchValue);

                this.OrderField = orderField;
                this.OrderDirection = orderDirection;
                return that.apiProvider.MonthlyTransactionSummary_List(pageSize, pageNumber, orderField, orderDirection,
                    that.SearchDateFrom, that.SearchDateTo).then(
                    (result: any) => {
                        if (result.HasError) {
                            throw "Data Load Error: " + result.Feedback;
                        }
                        that.totalCount = result.NumberOfRecords;
                        return {
                            data: result.MonthlyTransactionsList,
                            totalCount: result.NumberOfRecords,
                            summary: [result.TransactionalCountTotal, result.ETPValueTotal, result.SchoolDaysValueTotal]
                        };
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
                template: 'monthsFromDropDown'
            },
            {
                location: 'after',
                template: 'monthsToDropDown'
            }
        );
    }

    exportToExcel() {
        appGlobals.ShowGlobalLoader();
        this.apiProvider.MonthlyTransactionSummary_Export(this.OrderField, this.OrderDirection, this.SearchDateFrom, this.SearchDateTo).then(
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

    MonthFromChanged($event) {
        this.SearchDateFrom = $event.value;
        this.dataStore.load();
    }

    MonthToChanged($event) {
        this.SearchDateTo = $event.value;
        this.dataStore.load();
    }

    formatDateTimeColumn(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, true, true, true, true, false);
    }

    formatDateColumn(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, false, true, true, true);
    }
}