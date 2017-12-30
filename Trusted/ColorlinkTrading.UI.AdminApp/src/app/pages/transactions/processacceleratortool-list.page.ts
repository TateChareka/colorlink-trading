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
    selector: 'processacceleratortool-list.page',
    templateUrl: './processacceleratortool-list.page.html',
    styleUrls: ['./../../../theme/datagrid-toolbar.css', './processacceleratortool-list.page.css']
})

export class ProcessAcceleratorToolListPage {
    popupMailDeleteVisible = false;
    showError: boolean = false;
    debitOrderDate: Date = new Date();
    processState: boolean;
    fileName: string;
    AcceleratorTransactionList: any = [];
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

    uploadFile($event) {
        let files = $event.target.files;
        if (files.length > 0) {
            this.apiProvider.FileUsingIdentifier_Upload(files[0], "Accelerator_Tool_Processing").then(
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

    getAcceleratorTransaction() {
        if (this.fileName != null) {
            this.apiProvider.PrepareAcceleratorTool_GetTransactions(this.fileName, this.debitOrderDate).then(
                (result: any) => {
                    if (result.HasError) {
                        throw "Data Load Error: " + result.Feedback;
                    }
                    else {
                        this.AcceleratorTransactionList = result.AcceleratorTransactions;
                        this.hasContent = true;
                        this.hasError = result.RowsInValid;
                    }
                },
                (error) => {
                    throw "Data Load Error: " + error;
                });
        }
    }

    processAcceleratorTransactions() {
        if (this.hasError != true) {
            this.processState = false;
            this.apiProvider.ProcessAcceleratorTool_Write(this.fileName, this.debitOrderDate).then(
                (result: any) => {
                    if (result.HasError) {
                        throw "Data Load Error: " + result.Feedback;
                    }
                    else {
                        this.resultsFeedback = result.Feedback;
                        this.popupMailDeleteVisible = true;
                        this.AcceleratorTransactionList = null;
                        this.hasContent = false;
                        this.hasError = false;
                        this.fileName = null;
                        this.debitOrderDate = new Date();
                        this.errorContent = null;
                        appGlobals.ShowToastNotification("Accelerator Too Transaction Successfully Processed", "Success");
                        this.processState = true;
                    }
                },
                (error) => {
                    throw "Data Load Error: " + error;
                });
        }
    }

    closeFeedbackPopup() {
        this.popupMailDeleteVisible = false;
    }

}