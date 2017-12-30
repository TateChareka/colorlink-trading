import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from "../app/app.config";
import 'rxjs/add/operator/map';


@Injectable()
export class SdBaseService {

  constructor(public http: HttpClient) {
  }

  ServiceBase_Execute(location: string, requestData: any): any {
    return this.http.post(location, requestData, { headers: this.GetAdminHeaders() }).map(res => (res as any).json());
  }

  ServiceBase_ExecuteWithoutHeaders(location: string, requestData: any): any {
    return this.http.post(location, requestData).map(res => (res as any).json());
  }

  GetAdminHeaders() {
    var headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('lpcUref', this.GetLocalCacheValue());
    headers.append("ClientId", "151");
    return headers;
  }

  GetLocalCacheValue() {
    return window.localStorage.getItem(AppConfig.AUTH_LS_ADDRESS);
  }

}
