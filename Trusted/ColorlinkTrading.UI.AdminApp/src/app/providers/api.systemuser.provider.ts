import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APISystemUserService } from '../services/api.systemuser.service';

@Injectable()
export class APISystemUserProvider {

  constructor(private apiService: APISystemUserService) {
  }

  SystemUserProvider_SignIn(UserIdentifier: string, UserPassword: string) {
    return new Promise((result, exception) => {
      this.apiService.SystemUserService_SignIn(UserIdentifier, UserPassword).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  SystemUserProvider_SignInFromCache(UserAuthenticationGUID: string) {
    return new Promise((result, exception) => {
      this.apiService.SystemUserService_SignInFromCache(UserAuthenticationGUID).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
}

