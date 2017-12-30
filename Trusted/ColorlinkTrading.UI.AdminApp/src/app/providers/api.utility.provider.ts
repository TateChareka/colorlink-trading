import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIUtilityService } from '../services/api.utility.service';
import * as appGlobals from '../app-globals';

@Injectable()
export class APIUtilityProvider {

  constructor(private apiService: APIUtilityService) {
  }

  UtilityProvider_GetPeriodDates(period: string) {
    return new Promise((result, exception) => {
      this.apiService.UtilityService_GetPeriodDates(period).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  UtiltyProvider_DownloadMedia(mediaGUID: string) {
    var url: string = appGlobals.WebServiceURL + "/MediaService/DownloadFile?q=" + mediaGUID;
    window.open(url, "_blank");
  }
}

