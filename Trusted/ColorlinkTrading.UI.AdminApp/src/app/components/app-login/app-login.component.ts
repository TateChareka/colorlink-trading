import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APISystemUserProvider } from './../../providers/api.systemuser.provider';

@Component({
    selector: 'app-login',
    templateUrl: './app-login.component.html',
    styleUrls: ['./app-login.component.css']
})

export class ApplicationLoginComponent {

    UserIdentifier: string = "";
    UserPassword: string = "";

    constructor(private routeControl: Router, private apiProvider: APISystemUserProvider) {
        this.apiProvider.SystemUserProvider_SignInFromCache(appGlobals.GetLocalCacheValue()).then(
            (result: any) => {
                if (result.HasError) {
                    if (result.Feedback.indexOf("expired") != -1) {
                        appGlobals.ShowGlobalModal("Auto Login Expired", result.Feedback, "warning");                        
                    }
                }
                else {
                    appGlobals.SetLocalCacheValue(result.UserAuthenticationGUID);
                    appGlobals.SignUserIn();
                    this.routeControl.navigate(['/' + appGlobals.LandingPage]);                    
                }
            },
            (error) => {

            }
        )
    }

    isValidForm() {
        return (this.UserIdentifier != "" && this.UserPassword != "");
    }

    login() {
        this.apiProvider.SystemUserProvider_SignIn(this.UserIdentifier, this.UserPassword).then(
            (result: any) => {
                if (result.HasError) {
                    appGlobals.ShowGlobalModal("Login Error", result.Feedback, "warning");
                }
                else {
                    appGlobals.SetLocalCacheValue(result.UserAuthenticationGUID);
                    appGlobals.SignUserIn();
                    this.routeControl.navigate(['/' + appGlobals.LandingPage]);                    
                }
            },
            (error) => {
                appGlobals.ShowGlobalModal("Login Error", "Unknown Login Error has occurred", "warning");
            }
        );
    }

}
