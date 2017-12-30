import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APIFeesService {
    constructor(private api: APIServiceBase) { }

    location_FeesServiceRoot: string = appGlobals.WebServiceURL + "/FeeService/";

    location_ProcessAccountFees: string = this.location_FeesServiceRoot + "ProcessAccountFees";
    location_AccountFeesItem: string = this.location_FeesServiceRoot + "GetAccountFeesItem";
    location_GetAccountFeeMonths: string = this.location_FeesServiceRoot + "GetAccountFeeMonths";
    location_GetAccountFeeModels: string = this.location_FeesServiceRoot + "GetAccountFeeModels";
    location_WriteAccountFee: string = this.location_FeesServiceRoot + "WriteAccountFee";
    location_DeleteAccountFee: string = this.location_FeesServiceRoot + "DeleteAccountFee";


    ProcessAccountFees_Get(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_ProcessAccountFees, requestData);
    }

    AccountFeeItem_Get(itemId: number): any {
        var requestData = {
            ItemId: itemId
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeesItem, requestData);
    }

    AccountFeeMonths_Get(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_GetAccountFeeMonths, requestData);
    }

    AccountFeeModels_Get(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_GetAccountFeeModels, requestData);
    }

    AccountFee_Write(requestData: any): any { 
        return this.api.ServiceBase_Execute(this.location_WriteAccountFee, requestData);
    }
    AccountFee_Delete(accountfeeId: number): any {
        var requestData = {
            ItemId: accountfeeId
        };
        return this.api.ServiceBase_Execute(this.location_DeleteAccountFee, requestData);
    }

}