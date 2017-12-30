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
    selector: 'processspendingtool-list.page',
    templateUrl: './processspendingtool-list.page.html',
    styleUrls: ['./../../../theme/datagrid-toolbar.css', './processspendingtool-list.page.css']
})

export class ProcessSpendingToolListPage {
    popupMailDeleteVisible = false;
    showError: boolean = false;
    debitOrderDate: Date = new Date();
    processState: boolean;
    fileName: string;
    VendorsList: any = [];
    vendorId: number;
    lastVendorUploadDate: string;
    hasContent: boolean = false;
    hasError: boolean = false;
    errorContent: string;
    resultsFeedback: string;

    constructor(private routeControl: Router, private apiProvider: APITransactionsProvider, private apiUtility: APIUtilityProvider) {
        appGlobals.SetActivePageTitle("Process Accelerator Tool");
        if (!appGlobals.checkSignInCache()) {
            this.routeControl.navigate(['/' + appGlobals.LandingPage]);
        }
    }

    ngOnInit() {
        this.getVendors();
    }

    getVendors() {
        this.apiProvider.Vendors_Get().then(
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

    vendorChanged($event) {
        console.log($event.value);
        this.vendorId = $event.value;
        //this.lastVendorUploadDate = this.formatDateTimeColumn($event.value);
    }

    uploadFile($event) {
        let files = $event.target.files;
        if (files.length > 0) {
            this.apiProvider.FileUsingIdentifier_Upload(files[0], "Spending_Tool_Processing").then(
                (result: any) => {
                    if (result.HasError) {
                        throw "Data Load Error: " + result.Feedback;
                    }
                    else {
                        this.fileName = result.Feedback;
                        this.processState = true;
                    }
                },
                (error) => {
                    throw "Data Load Error";
                });
        }
    }

    processSpendingPartnerTransactions() {
        if (this.fileName != null) {
            this.apiProvider.SpendingPartner_Process(this.vendorId, this.fileName).then(
                (result: any) => {
                    if (result.HasError) {
                        throw "Data Load Error: " + result.Feedback;
                    }
                    else {
                        if (result.IsValidationError) {
                            this.hasError = true;
                            this.errorContent = result.Feedback
                        } else {
                            this.hasError = false;
                            this.errorContent = result.Feedback
                        }
                    }
                },
                (error) => {
                    throw "Data Load Error: " + error;
                });
        }
    }

    formatDateTimeColumn(cellInfo) {
        return appGlobals.GetStringDateGenericFromJSON(cellInfo.value, true, true, true, true, false);
    }

}