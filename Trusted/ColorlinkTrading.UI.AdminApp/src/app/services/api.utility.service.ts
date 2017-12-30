import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import {APIServiceBase} from './api.servicebase'

@Injectable()
export class APIUtilityService {
    constructor(private api: APIServiceBase) { }

    location_ServiceRoot: string = appGlobals.WebServiceURL + "/UtilityService/";
    location_GetPeriodDates: string = this.location_ServiceRoot + "GetPeriodDates";
    
    UtilityService_GetPeriodDates(period: string): any {
        var requestData = {
            Period: period
        };
        return this.api.ServiceBase_Execute(this.location_GetPeriodDates, requestData);
    }
}
