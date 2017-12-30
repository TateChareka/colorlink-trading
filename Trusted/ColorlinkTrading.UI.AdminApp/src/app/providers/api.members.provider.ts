import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APIMembersService } from '../services/api.members.service';

@Injectable()
export class APIMembersProvider {

  constructor(private apiService: APIMembersService) {
  }

  MemberList_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.MemberList_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberList_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.MemberList_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  NedbankFTPDownload_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.NedbankFTPDownload_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  NedbankFTPDownload_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.NedbankFTPDownload_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  NedbankActivationStatus_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.NedbankActivationStatus_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  NedbankActivationStatus_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.NedbankActivationStatus_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  DischemActivationStatus_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.DischemActivationStatus_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  DischemActivationStatus_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.DischemActivationStatus_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  StatementRuns_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.StatementRuns_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  StatementRuns_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.StatementRuns_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AcceleratorListings_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.AcceleratorListings_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AcceleratorListings_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.AcceleratorListings_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberStatements_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
    searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.MemberStatements_Search(pageSize, pageNumber, orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberStatements_Export(orderField: string, orderDirection: string, searchCriteria: string, dateFrom: Date, dateTo: Date) {
    return new Promise((result, exception) => {
      this.apiService.MemberStatements_Export(orderField, orderDirection, searchCriteria, dateFrom, dateTo).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  Member_DisableCommunications(memberAccountId: number) {
    return new Promise((result, exception) => {
      this.apiService.Member_DisableCommunications(memberAccountId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  Member_EnableCommunications(memberAccountId: number) {
    return new Promise((result, exception) => {
      this.apiService.Member_EnableCommunications(memberAccountId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  Member_Delete(memberId: number) {
    return new Promise((result, exception) => {
      this.apiService.Member_Delete(memberId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AcceleratorStatus_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.AcceleratorStatus_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AcceleratorStatus_Write(requestData: any): any {
    return new Promise((result, exception) => {
      this.apiService.AcceleratorStatus_Write(requestData).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  AcceleratorItem_Get(itemId: number): any {
    return new Promise((result, exception) => {
      this.apiService.AcceleratorItem_Get(itemId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MemberStatementsItem_Get(itemId: number): any {
    return new Promise((result, exception) => {
      this.apiService.MemberStatementsItem_Get(itemId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  UserGUID_Get(loginGUID: string): any {
		return new Promise((result, exception) => {
			this.apiService.UserGUID_Get(loginGUID).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}
  

}