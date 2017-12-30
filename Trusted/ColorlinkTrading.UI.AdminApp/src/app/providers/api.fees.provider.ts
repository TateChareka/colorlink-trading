import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIFeesService } from '../services/api.fees.service';

@Injectable()
export class APIFeesProvider {

  constructor(private apiService: APIFeesService) {
  }

  ProcessAccountFees_Get(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.ProcessAccountFees_Get(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AccountFeeItem_Get(itemId: number) {
    return new Promise((result, exception) => {
      this.apiService.AccountFeeItem_Get(itemId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AccountFeeMonths_Get() {
    return new Promise((result, exception) => {
      this.apiService.AccountFeeMonths_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AccountFeeModels_Get() {
    return new Promise((result, exception) => {
      this.apiService.AccountFeeModels_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AccountFee_Write(requestData: any): any { 
    return new Promise((result, exception) => {
      this.apiService.AccountFee_Write(requestData).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AccountFee_Delete(accountfeeId: number) {
    return new Promise((result, exception) => {
      this.apiService.AccountFee_Delete(accountfeeId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }


}