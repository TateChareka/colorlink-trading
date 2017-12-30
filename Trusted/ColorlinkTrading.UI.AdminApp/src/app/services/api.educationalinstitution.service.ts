import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APIEducationalInstitutionService {
    constructor(private api: APIServiceBase) { }    

    location_SchoolListsServiceRoot: string = appGlobals.WebServiceURL + "/EducationalInstitutionService/";

    location_SearchEducationalInstitutions: string = this.location_SchoolListsServiceRoot + "SearchEducationalInstitutions";
    location_WriteEducationalInstitution: string = this.location_SchoolListsServiceRoot + "WriteEducationalInstitution";
    location_DeleteEducationalInstitution: string = this.location_SchoolListsServiceRoot + "DeleteEducationalInstitution";
    location_GetEducationalInstitutionItems: string = this.location_SchoolListsServiceRoot + "GetEducationalInstitutionItem";

    EducationalInstitutions_Get(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_SearchEducationalInstitutions, requestData);
    }

    EducationalInstitution_Write(requestData: any): any { 
        return this.api.ServiceBase_Execute(this.location_WriteEducationalInstitution, requestData);
    }
    EducationalInstitution_Delete(educationalinstitutionId: number): any {
        var requestData = {
            ItemId: educationalinstitutionId
        };
        return this.api.ServiceBase_Execute(this.location_DeleteEducationalInstitution, requestData);
    }
    EducationalInstitutionItem_Get(itemId: number): any {
        var requestData = {
            ItemId: itemId
        };
        return this.api.ServiceBase_Execute(this.location_GetEducationalInstitutionItems, requestData);
    }

}