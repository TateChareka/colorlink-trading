import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APIEmployeesService {
    constructor(private api: APIServiceBase) { }

    location_EmployeessServiceRoot: string = appGlobals.WebServiceURL + "/EmployeesService/";

    location_ProcessAccountFees: string = this.location_EmployeessServiceRoot + "";


}