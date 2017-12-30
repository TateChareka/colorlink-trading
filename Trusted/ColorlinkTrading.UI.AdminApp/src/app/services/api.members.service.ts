import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APIMembersService {
    constructor(private api: APIServiceBase) { }
    location_ServiceRoot: string = appGlobals.WebServiceURL + "/SystemUserService/";
    location_UserGUID: string = this.location_ServiceRoot + "GetUserGUID";

    location_MembersServiceRoot: string = appGlobals.WebServiceURL + "/MemberService/";

    location_MemberSearch: string = this.location_MembersServiceRoot + "MemberSearch";
    location_MemberExport: string = this.location_MembersServiceRoot + "MemberExport";
    location_NedbankFTPDownloadSearch: string = this.location_MembersServiceRoot + "NedbankDownloadForFTPTransmissionSearch";
    location_NedbankFTPDownloadExport: string = this.location_MembersServiceRoot + "NedbankDownloadForFTPTransmissionExport";
    location_NedbankActivationStatusSearch: string = this.location_MembersServiceRoot + "NedbankActivationStatusSearch";
    location_NedbankActivationStatusExport: string = this.location_MembersServiceRoot + "NedbankActivationStatusExport";
    location_DischemActivationStatusSearch: string = this.location_MembersServiceRoot + "DischemActivationStatusSearch";
    location_DischemActivationStatusExport: string = this.location_MembersServiceRoot + "DischemActivationStatusExport";
    location_StatementRunsSearch: string = this.location_MembersServiceRoot + "StatementRunsSearch";
    location_StatementRunsExport: string = this.location_MembersServiceRoot + "StatementRunsExport";
    location_AcceleratorListingsSearch: string = this.location_MembersServiceRoot + "AcceleratorListingsSearch";
    location_AcceleratorListingsExport: string = this.location_MembersServiceRoot + "AcceleratorListingsExport";
    location_MemberStatementsSearch: string = this.location_MembersServiceRoot + "MemberStatementsSearch";
    location_MemberStatementsExport: string = this.location_MembersServiceRoot + "MemberStatementsExport";
    location_CheckCommunications: string = this.location_MembersServiceRoot + "CheckCommunications";
    location_DisableCommunications: string = this.location_MembersServiceRoot + "DisableCommunications";
    location_EnableCommunications: string = this.location_MembersServiceRoot + "EnableCommunications";
    location_DeleteMember: string = this.location_MembersServiceRoot + "DeleteMember";
    location_AcceleratorStatus: string = this.location_MembersServiceRoot + "GetAcceleratorStatus";
    location_WriteAcceleratorStatus: string = this.location_MembersServiceRoot + "WriteAcceleratorStatus";
    location_AcceleratorItem: string = this.location_MembersServiceRoot + "GetAcceleratorItem";
    location_MemberStatementsItem: string = this.location_MembersServiceRoot + "GetMemberStatementsItem";



    MemberList_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_MemberSearch, requestData);
    }

    MemberList_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_MemberExport, requestData);
    }

    NedbankFTPDownload_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_NedbankFTPDownloadSearch, requestData);
    }

    NedbankFTPDownload_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_NedbankFTPDownloadExport, requestData);
    }

    NedbankActivationStatus_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_NedbankActivationStatusSearch, requestData);
    }

    NedbankActivationStatus_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_NedbankActivationStatusExport, requestData);
    }

    DischemActivationStatus_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_DischemActivationStatusSearch, requestData);
    }

    DischemActivationStatus_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_DischemActivationStatusExport, requestData);
    }

    StatementRuns_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_StatementRunsSearch, requestData);
    }

    StatementRuns_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_StatementRunsExport, requestData);
    }

    AcceleratorListings_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_AcceleratorListingsSearch, requestData);
    }

    AcceleratorListings_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AcceleratorListingsExport, requestData);
    }

    MemberStatements_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_MemberStatementsSearch, requestData);
    }

    MemberStatements_Export(orderField: string, orderDirection: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_MemberStatementsExport, requestData);
    }

    Member_DisableCommunications(memberAccountId: number): any {
        var requestData = {
            ItemId: memberAccountId
        };
        return this.api.ServiceBase_Execute(this.location_DisableCommunications, requestData);
    }

    Member_EnableCommunications(memberAccountId: number): any {
        var requestData = {
            ItemId: memberAccountId
        };
        return this.api.ServiceBase_Execute(this.location_EnableCommunications, requestData);
    }

    Member_Delete(memberId: number): any {
        var requestData = {
            ItemId: memberId
        };
        return this.api.ServiceBase_Execute(this.location_DeleteMember, requestData);
    }

    AcceleratorStatus_Get(): any {
        var requestData = {};
        return this.api.ServiceBase_Execute(this.location_AcceleratorStatus, requestData);
    }

    AcceleratorStatus_Write(requestData: any): any {
        return this.api.ServiceBase_Execute(this.location_WriteAcceleratorStatus, requestData);
    }

    AcceleratorItem_Get(itemId: number): any {
        var requestData = {
            ItemId: itemId
        };
        return this.api.ServiceBase_Execute(this.location_AcceleratorItem, requestData);
    }

    MemberStatementsItem_Get(itemId: number): any {
        var requestData = {
            ItemId: itemId
        };
        return this.api.ServiceBase_Execute(this.location_MemberStatementsItem, requestData);
    }

    UserGUID_Get(loginGUID: string): any {
        var requestData = {
            LoginGUID: loginGUID,
        };
        return this.api.ServiceBase_Execute(this.location_UserGUID, requestData);
    }

}