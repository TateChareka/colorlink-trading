import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APICommunicationsProvider } from './../../providers/api.communications.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';
import { SafeResourceUrl, DomSanitizer } from '@angular/platform-browser';

import {
    DxDataGridModule, DxDateBoxModule, DxLoadPanelModule,
    DxTextBoxModule, DxResponsiveBoxModule, DxPopupModule,
    DxButtonModule, DxFormModule, DxFormComponent,
    DxButtonComponent,
} from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
    selector: 'messagelogs-list',
    templateUrl: './messagelogs-list.page.html',
    styleUrls: ['./../../../theme/datagrid-toolbar.css', './messagelogs-list.page.css']
})

export class MessageLogsListPage {
    mailContentSRC: SafeResourceUrl = null;
    SMSContent: boolean = false;
    EmailContent: boolean = false;
    popupMailDeleteVisible: boolean = false;
    showError: boolean = false;
    gridData: any = {};
    dataStore: any = {};
    SearchDateFrom = new Date(2010, 1, 1);
    SearchDateTo = new Date();
    totalCount: number = 0;
    SearchText: string = "";
    SearchPeriod: string = "ThisMonth";
    BrandName: string = "";
    MessageType: string = "";
    ActionRow: any = {};
    MsgBody: string = "";
    BrandNamesList: any = [];
    MessageTypesList: any = [];

    constructor(private routeControl: Router, private apiProvider: APICommunicationsProvider, private apiUtility: APIUtilityProvider, private sanitizer: DomSanitizer) {
        appGlobals.SetActivePageTitle("Message Logs");
        if (!appGlobals.checkSignInCache()) {
            this.routeControl.navigate(['/' + appGlobals.LandingPage]);
        }
    }

    ngOnInit() {
        this.getBrandNames();
        this.getMessageTypes();
    }

    ngAfterContentInit() {
        var that = this;
        this.dataStore = new DataSource({
            load: function (loadOptions) {
                var orderField = loadOptions.sort ? loadOptions.sort[0].selector : "DateSent";
                var orderDirection = (loadOptions.sort && loadOptions.sort[0].desc) ? "ASC" : "DESC";
                var pageNumber = (loadOptions.skip / loadOptions.take) + 1;
                var pageSize = loadOptions.take;
                var filter = (loadOptions.searchValue == null ? "" : loadOptions.searchValue);

                this.SearchText = filter;
                return that.apiUtility.UtilityProvider_GetPeriodDates(that.SearchPeriod).then(
                    (result: any) => {
                        //grab the dates from the result
                        that.SearchDateFrom = result.StartDateString;
                        that.SearchDateTo = result.EndDateString;
                        //filter the data
                        return that.apiProvider.MessageLogs_Search(pageSize, pageNumber, orderField, orderDirection, that.BrandName, that.MessageType,
                            that.SearchDateFrom, that.SearchDateTo, filter).then(
                            (result: any) => {
                                if (result.HasError) {
                                    throw "Data Load Error: " + result.Feedback;
                                }
                                that.totalCount = result.NumberOfRecords;
                                return {
                                    data: result.MessageLogs,
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
                template: 'brandDropDown'
            },
            {
                location: 'after',
                template: 'messageTypeDropdown'
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
            }
        );
    }

    getBrandNames() {
        this.apiProvider.MessageLogsBrandName_Get().then(
            (result: any) => {
                if (result.HasError) {
                    throw "Data Load Error: " + result.Feedback;
                }
                this.BrandNamesList = result.data;
            },
            (error) => {
                throw "Data Load Error";
            });
    }

    brandNamesChanged($event) {
        this.BrandName = $event.value;
        this.dataStore.load();
    }

    getMessageTypes() {
        this.apiProvider.MessageLogsMessageType_Get().then(
            (result: any) => {
                if (result.HasError) {
                    throw "Data Load Error: " + result.Feedback;
                }
                this.MessageTypesList = result.data;
            },
            (error) => {
                throw "Data Load Error";
            });
    }

    messageTypesChanged($event) {
        this.MessageType = $event.value;
        this.dataStore.load();
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

    viewMessageContent() {
        if (this.ActionRow.MessageTypeDescription == "Email") {
            this.SMSContent = false;
            this.EmailContent = true;

        } else {
            this.SMSContent = true;
            this.EmailContent = false;
        }
        this.mailContentSRC = this.sanitizer.bypassSecurityTrustResourceUrl(appGlobals.WebServiceURL + '/CommunicationsMessageLogService/GetMessageContent?identifier=' + this.ActionRow.MessageGUID + '');
        this.popupMailDeleteVisible = true;
    }

    closeMessageContent() {
        this.popupMailDeleteVisible = false;
    }

}