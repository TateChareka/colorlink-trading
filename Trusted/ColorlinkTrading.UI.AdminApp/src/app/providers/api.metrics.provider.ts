import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIMetricsService } from '../services/api.metrics.service';

@Injectable()
export class APIMetricsProvider {

  constructor(private apiService: APIMetricsService) {
  }

  MetricsService_Members() {
    return new Promise((result, exception) => {
      this.apiService.MetricsService_Members().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MetricsService_Communications() {
    return new Promise((result, exception) => {
      this.apiService.MetricsService_Communications().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberMetrics_Get(datefrom: Date, dateto: Date): any {
    return new Promise((result, exception) => {
      this.apiService.MemberMetrics_Get(datefrom, dateto).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberMetricsMonths_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.MemberMetricsMonths_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
}

