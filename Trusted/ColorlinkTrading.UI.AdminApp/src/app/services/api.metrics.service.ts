import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import {APIServiceBase} from './api.servicebase'

@Injectable()
export class APIMetricsService {
    constructor(private api: APIServiceBase) { }

    location_MetricsServiceRoot: string = appGlobals.WebServiceURL + "/MetricsService/";
    
    location_MemberMetrics: string = this.location_MetricsServiceRoot + "Members";
    location_CommunicationMetrics: string = this.location_MetricsServiceRoot + "Communications";

    location_GetMemberMetrics: string = this.location_MetricsServiceRoot + "GetMembersMetrics";
    location_GetMemberMetricMonths: string = this.location_MetricsServiceRoot + "GetMemberMetricMonths";
    
    MetricsService_Members(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_MemberMetrics, requestData);
    }

    MetricsService_Communications(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_CommunicationMetrics, requestData);
    }

    MemberMetrics_Get(datefrom: Date, dateto: Date): any {
        var requestData = {            
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_GetMemberMetrics, requestData);
    }

    MemberMetricsMonths_Get(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_GetMemberMetricMonths, requestData);
    }

}
