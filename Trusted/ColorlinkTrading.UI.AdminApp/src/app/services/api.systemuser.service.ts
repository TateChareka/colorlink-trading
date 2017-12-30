import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import {APIServiceBase} from './api.servicebase'

@Injectable()
export class APISystemUserService {
    constructor(private api: APIServiceBase) { }

    location_ServiceRoot: string = appGlobals.WebServiceURL + "/SystemUserService/";
    location_SignIn: string = this.location_ServiceRoot + "SignIn";
    location_UserGUID: string = this.location_ServiceRoot + "GetUserGUID";
    
    SystemUserService_SignIn(UserIdentifier: string, UserPassword: string): any {
        var requestData = {
            UserIdentifier: UserIdentifier,
            UserPassword: UserPassword,
            SignInEnvironment: "Administration"
        };
        return this.api.ServiceBase_ExecuteWithoutHeaders(this.location_SignIn, requestData);
    }

    SystemUserService_SignInFromCache(UserAuthenticationGUID: string): any {
        var requestData = {
            UserIdentifier: "",
            UserPassword: "",
            UserAuthenticationGUID: UserAuthenticationGUID,
            SignInEnvironment: "Administration"
        };
        return this.api.ServiceBase_ExecuteWithoutHeaders(this.location_SignIn, requestData);
    }
    

}
