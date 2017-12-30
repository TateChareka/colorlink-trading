import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase';
import { Http, Headers } from '@angular/http';

@Injectable()
export class APIMediaService {
    constructor(private api: APIServiceBase, private http: Http) { }

    location_MediaServiceRoot: string = appGlobals.WebServiceURL + "/MediaService/";
    location_UploadFileUsingIdentifier: string = this.location_MediaServiceRoot + "UploadFileUsingIdentifier";

    FileUsingIdentifier_Upload(files: File, fileTypeIdentifier: string): any {
        var that = this;
        return new Promise(function (resolve, reject) {
            let xhr: XMLHttpRequest = new XMLHttpRequest();
            xhr.open('POST', that.location_UploadFileUsingIdentifier, true);            
            xhr.setRequestHeader("lpcUref", appGlobals.GetLocalCacheValue());
            xhr.setRequestHeader("SignInEnvironment", 'Administration'); 
            let formData = new FormData();
            formData.append("file", files, files.name);
            formData.append("FileTypeIdentifier", fileTypeIdentifier);            
            xhr.addEventListener('load', function () {
                if (this.status >= 200 && this.status < 300) {
                    var responseData: any = JSON.parse(xhr.response);
                    resolve(responseData);
                } else {
                    reject({
                        status: this.status,
                        statusText: xhr.statusText
                    });
                }
            });
            xhr.addEventListener('error', function () {
                reject({
                    status: this.status,
                    statusText: xhr.statusText
                });
            });
            xhr.send(formData);
        });
    }

    




}