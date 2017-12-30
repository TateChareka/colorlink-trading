import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIGrowthService } from '../services/api.growth.service';

@Injectable()
export class APIGrowthProvider {

  constructor(private apiService: APIGrowthService) {
  }


}