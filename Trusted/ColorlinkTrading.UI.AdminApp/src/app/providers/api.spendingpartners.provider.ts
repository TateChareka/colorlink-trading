import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APISpendingPartnerService } from '../services/api.spendingpartners.service';

@Injectable()
export class APISpendingPartnerProvider {

  constructor(private apiService: APISpendingPartnerService) {
  }

  SpendingPartnerList_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.SpendingPartnerList_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  SpendingPartner_Delete(memberId: number) {
    return new Promise((result, exception) => {
      this.apiService.SpendingPartner_Delete(memberId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
}