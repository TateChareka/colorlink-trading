import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APICommunicationsService {
    constructor(private api: APIServiceBase) { }

    location_CommunicationsServiceRoot: string = appGlobals.WebServiceURL + "/CommunicationsService/";
    location_GetMessageTypes: string = this.location_CommunicationsServiceRoot + "GetMessageTypes";
    location_GetStatementDates: string = this.location_CommunicationsServiceRoot + "GetStatementDates";
    location_GetEmails: string = this.location_CommunicationsServiceRoot + "GetEmails";
    location_GetHTMLBody: string = this.location_CommunicationsServiceRoot + "GetHTMLBody";
    location_DeleteEmail: string = this.location_CommunicationsServiceRoot + "DeleteEmail";


    location_CommunicationsMessageServiceRoot: string = appGlobals.WebServiceURL + "/CommunicationsMessageService/";
    location_CommunicationsMessageSearch: string = this.location_CommunicationsMessageServiceRoot + "CommunicationsMessageSearch";
    location_CommunicationsFilterDataCount: string = this.location_CommunicationsMessageServiceRoot + "CommunicationsFilterDataCount";
    location_WriteCommunicationMessage: string = this.location_CommunicationsMessageServiceRoot + "Write";
    location_SendTest: string = this.location_CommunicationsMessageServiceRoot + "SendTest";
    location_MultiSendTest: string = this.location_CommunicationsMessageServiceRoot + "MultiSendTest";
    location_QueueMessage: string = this.location_CommunicationsMessageServiceRoot + "QueueMessage";
    location_RemoveMessage: string = this.location_CommunicationsMessageServiceRoot + "RemoveMessage";
    location_CopyAndEdit: string = this.location_CommunicationsMessageServiceRoot + "CopyAndEdit";
    location_CommunicationMessageItem: string = this.location_CommunicationsMessageServiceRoot + "GetCommunicationMessageItem";
    location_GetImapEmailLinks: string = this.location_CommunicationsMessageServiceRoot + "GetImapEmailLinks";
    location_GetTemplateEmailLinks: string = this.location_CommunicationsMessageServiceRoot + "GetTemplateEmailLinks";

    location_CommunicationsTypeServiceRoot: string = appGlobals.WebServiceURL + "/CommunicationsTypeService/";
    location_CommunicationType: string = this.location_CommunicationsTypeServiceRoot + "CommunicationTypeDelete";
    location_CommunicationTypeItem: string = this.location_CommunicationsTypeServiceRoot + "GetCommunicationTypeItem";
    location_WriteCommunicationType: string = this.location_CommunicationsTypeServiceRoot + "WriteCommunicationType";
    location_CommunicationTypesBrandName: string = this.location_CommunicationsTypeServiceRoot + "GetCommunicationTypesBrandName";
    location_CommunicationsTypesSearch: string = this.location_CommunicationsTypeServiceRoot + "CommunicationsTypesSearch";

    location_CommunicationsTemplateServiceRoot: string = appGlobals.WebServiceURL + "/CommunicationsTemplateService/";
    location_GetCommunicationTemplates: string = this.location_CommunicationsTemplateServiceRoot + "GetCommunicationTemplates";
    location_CommunicationsTemplateSearch: string = this.location_CommunicationsTemplateServiceRoot + "CommunicationsTemplateSearch";
    location_CommunicationTemplate: string = this.location_CommunicationsTemplateServiceRoot + "DeleteCommunicationTemplate";
    location_CommunicationTemplateItem: string = this.location_CommunicationsTemplateServiceRoot + "GetCommunicationTemplateItem";
    location_WriteCommunicationTemplate: string = this.location_CommunicationsTemplateServiceRoot + "WriteCommunicationTemplate";
    location_GetCommunicationTypes: string = this.location_CommunicationsTemplateServiceRoot + "GetCommunicationTypes";
    location_CommunicationTemplateBrandName: string = this.location_CommunicationsTemplateServiceRoot + "GetCommunicationTemplateBrandName";

    location_CommunicationsMessageLogServiceRoot: string = appGlobals.WebServiceURL + "/CommunicationsMessageLogService/";
    location_MessageLogsSearch: string = this.location_CommunicationsMessageLogServiceRoot + "CommunicationMessageLogsSearch";
    location_MessageLogsBrandNames: string = this.location_CommunicationsMessageLogServiceRoot + "GetCommMessageLogsBrandName";
    location_MessageLogsMessageType: string = this.location_CommunicationsMessageLogServiceRoot + "GetCommMessageLogsMessageType";


    CommunicationMessages_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationsMessageSearch, requestData);
    }

    CommunicationMessages_Write(communicationMessage: any): any {
        var requestData = communicationMessage;
        return this.api.ServiceBase_Execute(this.location_WriteCommunicationMessage, requestData);
    }

    CommunicationMessages_GetImapEmailLinks(imapUID: any): any {
        var requestData = {
            "ItemId": imapUID
        };
        return this.api.ServiceBase_Execute(this.location_GetImapEmailLinks, requestData);
    }

    CommunicationMessages_GetTemplateEmailLinks(templateId: any): any {
        var requestData = {
            "ItemId": templateId
        };
        return this.api.ServiceBase_Execute(this.location_GetTemplateEmailLinks, requestData);
    }

    CommunicationTemplate_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationsTemplateSearch, requestData);
    }

    CommunicationType_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationsTypesSearch, requestData);
    }

    MessageLogs_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, messageType: string, datefrom: Date, dateto: Date, searchCriteria: string): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            MessageType: messageType,
            SearchCriteria: searchCriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_MessageLogsSearch, requestData);
    }

    MessageLogsBrandName_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_MessageLogsBrandNames, requestData);
    }

    MessageLogsMessageType_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_MessageLogsMessageType, requestData);
    }

    CommunicationTypeItem_Get(commTypeId: number): any {
        var requestData = {
            ItemId: commTypeId
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationTypeItem, requestData);
    }
    CommunicationTemplateItem_Get(commTemplateId: number): any {
        var requestData = {
            ItemId: commTemplateId
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationTemplateItem, requestData);
    }
    CommunicationTemplate_Delete(commTemplateId: number): any {
        var requestData = {
            ItemId: commTemplateId
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationTemplate, requestData);
    }
    CommunicationType_Delete(commTypeId: number): any {
        var requestData = {
            ItemId: commTypeId
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationType, requestData);
    }

    CommunicationType_Write(requestData: any): any {
        return this.api.ServiceBase_Execute(this.location_WriteCommunicationType, requestData);
    }
    CommunicationTemplate_Write(requestData: any): any {
        return this.api.ServiceBase_Execute(this.location_WriteCommunicationTemplate, requestData);
    }

    CommunicationTypesBrandName_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationTypesBrandName, requestData);
    }

    CommunicationTemplateBrandName_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationTemplateBrandName, requestData);
    }

    CommunicationTypes_Get(brandname: string, includeSystemCommunication: boolean): any {
        var requestData = {
            BrandName: brandname,
            IsSystemCommunication: includeSystemCommunication
        };
        return this.api.ServiceBase_Execute(this.location_GetCommunicationTypes, requestData);
    }

    StatementDates_Get(brandname: string): any {
        var requestData = {
            BrandName: brandname
        };
        return this.api.ServiceBase_Execute(this.location_GetStatementDates, requestData);
    }

    MessageType_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_GetMessageTypes, requestData);
    }

    Emails_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_GetEmails, requestData);
    }

    HTMLBody_Get(imapuID: number): any {
        var requestData = {
            ItemId: imapuID
        };
        return this.api.ServiceBase_Execute(this.location_GetHTMLBody, requestData);
    }

    Email_Delete(imapuID: number): any {
        var requestData = {
            ItemId: imapuID
        };
        return this.api.ServiceBase_Execute(this.location_DeleteEmail, requestData);
    }

    CommunicationMessageItem_Get(commMessageId: number): any {
        var requestData = {
            ItemId: commMessageId
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationMessageItem, requestData);
    }

    CommunicationTemplates_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_GetCommunicationTemplates, requestData);
    }

    CommunicationsFilterDataCount_Get(filterCriteria: any): any {
        var requestData = {
            FilterCriteria: filterCriteria
        };
        return this.api.ServiceBase_Execute(this.location_CommunicationsFilterDataCount, requestData);
    }

    CommunicationsMessages_SendTest(communicationMessageId: number): any {
        var requestData = {
            CommunicationMessageId: communicationMessageId
        };
        return this.api.ServiceBase_Execute(this.location_SendTest, requestData);
    }

    CommunicationsMessages_RemoveMessage(communicationMessageId: number): any {
        var requestData = {
            CommunicationMessageId: communicationMessageId
        };
        return this.api.ServiceBase_Execute(this.location_RemoveMessage, requestData);
    }

    CommunicationsMessages_QueueMessage(communicationMessageId: number): any {
        var requestData = {
            CommunicationMessageId: communicationMessageId
        };
        return this.api.ServiceBase_Execute(this.location_QueueMessage, requestData);
    }

    CommunicationsMessages_CopyEdit(communicationMessageId: number): any {
        var requestData = {
            CommunicationMessageId: communicationMessageId
        };
        return this.api.ServiceBase_Execute(this.location_CopyAndEdit, requestData);
    }

    CommunicationsMessages_MultiSendTest(communicationMessageId: number, recipients: string): any {
        var requestData = {
            CommunicationMessageId: communicationMessageId,
            TestRecipients: recipients
        };
        return this.api.ServiceBase_Execute(this.location_MultiSendTest, requestData);
    }

}
