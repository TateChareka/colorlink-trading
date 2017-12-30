import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIEmployeesService } from '../services/api.employees.service';

@Injectable()
export class APIEmployeesProvider {

  constructor(private apiService: APIEmployeesService) {
  }


}