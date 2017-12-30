import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APISpendingPartnerService {
    constructor(private api: APIServiceBase) { }

    location_SpendingPartnerServiceRoot: string = appGlobals.WebServiceURL + "/SpendingPartnerService/";

    location_SpendingPartnerSearch: string = this.location_SpendingPartnerServiceRoot + "SpendingPartnerSearch";
    location_DeleteSpendingPartner: string = this.location_SpendingPartnerServiceRoot + "DeleteSpendingPartner";


    SpendingPartnerList_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_SpendingPartnerSearch, requestData);
    }

    SpendingPartner_Delete(SpendingPartnerId: number): any {
        var requestData = {
            ItemId: SpendingPartnerId
        };
        return this.api.ServiceBase_Execute(this.location_DeleteSpendingPartner, requestData);
    }
}