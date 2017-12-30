import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIEducationalInstitutionService } from '../services/api.educationalinstitution.service';

@Injectable()
export class APIEducationalInstitutionProvider {

  constructor(private apiService: APIEducationalInstitutionService) {
  }

  EducationalInstitutions_Get(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.EducationalInstitutions_Get(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  EducationalInstitutionItem_Get(itemId: number) {
    return new Promise((result, exception) => {
      this.apiService.EducationalInstitutionItem_Get(itemId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  EducationalInstitution_Write(requestData: any): any { 
    return new Promise((result, exception) => {
      this.apiService.EducationalInstitution_Write(requestData).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  EducationalInstitution_Delete(educationalinstitutionId: number) {
    return new Promise((result, exception) => {
      this.apiService.EducationalInstitution_Delete(educationalinstitutionId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

}