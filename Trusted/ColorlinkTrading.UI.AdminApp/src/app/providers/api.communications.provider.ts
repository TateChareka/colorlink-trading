import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APICommunicationsService } from '../services/api.communications.service';
import { APIMediaService } from '../services/api.media.service';

@Injectable()
export class APICommunicationsProvider {

  constructor(private apiService: APICommunicationsService, private apiMediaService: APIMediaService) {
  }

  CommunicationMessages_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, datefrom: Date, dateto: Date) {
    return new Promise((result, exception) => {
      this.apiService.CommunicationMessages_List(pageSize, pageNumber, orderField, orderDirection, datefrom, dateto).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationMessages_Write(communicationMessage: any) {
    return new Promise((result, exception) => {
      this.apiService.CommunicationMessages_Write(communicationMessage).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTemplate_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, datefrom: Date, dateto: Date) {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplate_List(pageSize, pageNumber, orderField, orderDirection, brandname, datefrom, dateto).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationType_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, datefrom: Date, dateto: Date) {
    return new Promise((result, exception) => {
      this.apiService.CommunicationType_List(pageSize, pageNumber, orderField, orderDirection, brandname, datefrom, dateto).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MessageLogs_Search(pageSize: number, pageNumber: number, orderField: string, orderDirection: string, brandname: string, messageType: string, datefrom: Date, dateto: Date, searchCriteria: string) {
    return new Promise((result, exception) => {
      this.apiService.MessageLogs_Search(pageSize, pageNumber, orderField, orderDirection, brandname, messageType, datefrom, dateto, searchCriteria).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MessageLogsBrandName_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.MessageLogsBrandName_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  MessageLogsMessageType_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.MessageLogsMessageType_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTypeItem_Get(commTypeId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTypeItem_Get(commTypeId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
  CommunicationTemplateItem_Get(commTemplateId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplateItem_Get(commTemplateId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
  CommunicationTemplate_Delete(commTemplateId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplate_Delete(commTemplateId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
  CommunicationType_Delete(commTypeId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationType_Delete(commTypeId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationType_Write(requestData: any): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationType_Write(requestData).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
  CommunicationTemplate_Write(requestData: any): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplate_Write(requestData).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTypesBrandName_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTypesBrandName_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTemplateBrandName_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplateBrandName_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTypes_Get(brandname: string, includeSystemCommunication: boolean): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTypes_Get(brandname, includeSystemCommunication).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  StatementDates_Get(brandname: string): any {
    return new Promise((result, exception) => {
      this.apiService.StatementDates_Get(brandname).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }


  MessageType_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.MessageType_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  Emails_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.Emails_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  HTMLBody_Get(imapuID: number): any {
    return new Promise((result, exception) => {
      this.apiService.HTMLBody_Get(imapuID).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  Email_Delete(imapuID: number): any {
    return new Promise((result, exception) => {
      this.apiService.Email_Delete(imapuID).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  FileUsingIdentifier_Upload(files: File, fileTypeIdentifier: string): any {
    return new Promise((result, exception) => {
      this.apiMediaService.FileUsingIdentifier_Upload(files, fileTypeIdentifier).then(
        (response: any) => {
          result(response);
        },
        (error) => {
          (exception(error));
        });
    });
  }

  CommunicationMessageItem_Get(commMessageId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationMessageItem_Get(commMessageId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationMessage_GetImapEmailLinks(imapUID: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationMessages_GetImapEmailLinks(imapUID).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationMessage_GetTemplateEmailLinks(templateId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationMessages_GetTemplateEmailLinks(templateId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationTemplates_Get(): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationTemplates_Get().subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }
  CommunicationsFilterDataCount_Get(filterCriteria: any): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsFilterDataCount_Get(filterCriteria).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationsMessages_SendTest(communicationMessageId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsMessages_SendTest(communicationMessageId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationsMessages_MultiSendTest(communicationMessageId: number, recipients: string): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsMessages_MultiSendTest(communicationMessageId, recipients).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationsMessages_RemoveMessage(communicationMessageId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsMessages_RemoveMessage(communicationMessageId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationsMessages_QueueMessage(communicationMessageId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsMessages_QueueMessage(communicationMessageId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }

  CommunicationsMessages_CopyEdit(communicationMessageId: number): any {
    return new Promise((result, exception) => {
      this.apiService.CommunicationsMessages_CopyEdit(communicationMessageId).subscribe(
        response => {
          result(response);
        },
        error => { exception(error); });
    });
  }


}