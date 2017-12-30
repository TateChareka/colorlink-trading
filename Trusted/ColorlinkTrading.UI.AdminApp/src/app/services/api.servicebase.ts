import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http'; 
import 'rxjs/Rx'; 
import * as appGlobals from'../app-globals';

@Injectable()
export class APIServiceBase {
    constructor(private http: Http){ }

    ServiceBase_Execute(location: string, requestData: any): any { 
        var r = this.http.post(location, requestData, { headers: appGlobals.GetAdminHeaders() }).map(res => res.json());
        return r;
    }

    ServiceBase_ExecuteWithoutHeaders(location: string, requestData: any): any { 
        var r = this.http.post(location, requestData).map(res => res.json());
        return r;
    }

}
