import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APIGrowthService {
    constructor(private api: APIServiceBase) { }

    location_GrowthsServiceRoot: string = appGlobals.WebServiceURL + "/GrowthService/";

    location_ProcessAccountFees: string = this.location_GrowthsServiceRoot + "";


}