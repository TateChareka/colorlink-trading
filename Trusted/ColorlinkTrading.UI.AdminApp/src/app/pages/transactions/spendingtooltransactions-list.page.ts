import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APITransactionsProvider } from './../../providers/api.transactions.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxSelectBoxModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
    selector: 'spendingtooltransactions-list',
    templateUrl: './spendingtooltransactions-list.page.html',
    styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class SpendingToolTransactionsListPage {

    showError: boolean = false;
    gridData: any = {};
    dataStore: any = {};
    SearchDateFrom: Date = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
    SearchDateTo: Date = new Date();
    totalCount: number = 0;


    VendorId = 0;
    SearchText: string = "";
    OrderField: string = "TransactionDateTime";
    OrderDirection: string = "ASC";
    VendorsList: any = [];
    VendorMonths: any = [];
    DateSelection: any = ["Transaction Date", "Invoice Date", "Payment Date"];
    DateUsed: string = "Transaction Date";

    constructor(private routeControl: Router, private apiProvider: APITransactionsProvider, private apiUtility: APIUtilityProvider) {
        appGlobals.SetActivePageTitle("Spending Tool Transactions");
        if (!appGlobals.checkSignInCache()) {
            this.routeControl.navigate(['/' + appGlobals.LandingPage]);
        }
    }

    ngOnInit() {
        this.getVendors();
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

                this.SearchText = filter;
                this.OrderField = orderField;
                this.OrderDirection = orderDirection;
                var dateused = that.DateUsed;
                return that.apiProvider.SpendingToolTransactions_List(pageSize, pageNumber, orderField, orderDirection,
                    that.VendorId, filter, that.SearchDateFrom, that.SearchDateTo, dateused).then(
                    (result: any) => {
                        if (result.HasError) {
                            throw "Data Load Error: " + result.Feedback;
                        }
                        that.totalCount = result.NumberOfRecords;
                        return {
                            data: result.SpendingToolList,
                            totalCount: result.NumberOfRecords,
                            summary: [result.RevenueTotal, result.SchooldaysAmountTotal, result.EduTimePointsTotal, result.SalesAmountTotal, result.SchooldaysValueTotal, result.BeneficiaryCountTotal, result.AvgPricePerSchooldayTotal]
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
                template: 'vendorsDropDown'
            },
            {
                location: 'after',
                template: 'monthFromDropDown'
            },
            {
                location: 'after',
                template: 'monthToDropDown'
            },
            {
                location: 'after',
                template: 'dateDropDown'
            },
            {
                location: 'after',
                template: 'searchTransactions'
            }
        );
    }

    getVendors() {
        this.apiProvider.SpendingVendors_Get().then(
            (result: any) => {
                if (result.HasError) {
                    throw "Data Load Error: " + result.Feedback;
                }
                this.VendorsList = result.Vendors;
            },
            (error) => {
                throw "Data Load Error";
            });
    }

    VendorChanged($event) {
        this.VendorId = $event.value;
        this.dataStore.load();
    }

    exportToExcel() {
        appGlobals.ShowGlobalLoader();
        this.apiProvider.SpendingToolTransactions_Export(this.OrderField, this.OrderDirection, this.VendorId,
            this.SearchText, this.SearchDateFrom, this.SearchDateTo, this.DateUsed).then(
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

    TextFilterChanged($event) {
        this.SearchText = $event.value;
        this.dataStore.searchValue(this.SearchText);
        this.dataStore.load();
    }

    MonthFromChanged($event) {
        this.SearchDateFrom = $event.value;
        this.dataStore.load();
    }

    MonthToChanged($event) {
        this.SearchDateTo = $event.value;
        this.dataStore.load();
    }

    DateSelectionChanged($event) {
        this.DateUsed = $event.value;
        this.dataStore.load();
    }

    formatDateColumn(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, true, true, true, false);
    }

    formatDateTimeColumn(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, true, true, true, true, false);	
    }

    getMonthYear(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, false, false, true, true, true);
    }
}