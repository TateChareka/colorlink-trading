import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import * as appGlobals from '../app-globals';
import { APIServiceBase } from './api.servicebase'

@Injectable()
export class APITransactionsService {
    constructor(private api: APIServiceBase) { }

    location_TransactionsServiceRoot: string = appGlobals.WebServiceURL + "/TransactionService/";
    location_GetVendors: string = this.location_TransactionsServiceRoot + "GetVendors";
    location_ProcessSpendingTooltransactions: string = this.location_TransactionsServiceRoot + "ProcessSpendingTooltransactions";

    location_TransactionsValueToolServiceRoot: string = appGlobals.WebServiceURL + "/TransactionsValueToolService/";
    location_ValueToolTransactionsList: string = this.location_TransactionsValueToolServiceRoot + "ValueToolTransactionsList";
    location_ValueToolTransactionsExport: string = this.location_TransactionsValueToolServiceRoot + "ValueToolTransactionsExport";

    location_TransactionsSpendingToolServiceRoot: string = appGlobals.WebServiceURL + "/TransactionsSpendingToolService/";
    location_SpendingToolSummaryList: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingToolSummaryList";
    location_SpendingToolSummaryExport: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingToolSummaryExport";
    location_SpendingVendorMonths: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingVendorMonths";
    location_SpendingVendors: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingVendors";
    location_SpendingToolTransactionsList: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingToolTransactionsList";
    location_SpendingToolTransactionsExport: string = this.location_TransactionsSpendingToolServiceRoot + "SpendingToolTransactionsExport";

    location_TransactionsMonthlyTransactionsServiceRoot: string = appGlobals.WebServiceURL + "/MonthlyTransactionsService/";
    location_MonthlyTransactionSummaryList: string = this.location_TransactionsMonthlyTransactionsServiceRoot + "MonthlyTransactionSummaryList";
    location_MonthlyTransactionSummaryExport: string = this.location_TransactionsMonthlyTransactionsServiceRoot + "MonthlyTransactionSummaryExport";
    location_MonthlyTransactionSummaryMonths: string = this.location_TransactionsMonthlyTransactionsServiceRoot + "MonthlyTransactionSummaryMonths";


    location_TransactionsAcceleratorToolServiceRoot: string = appGlobals.WebServiceURL + "/TransactionAcceleratorToolService/";
    location_AcceleratorToolTransactionsList: string = this.location_TransactionsAcceleratorToolServiceRoot + "AcceleratorToolTransactionsList";
    location_AcceleratorToolTransactionsExport: string = this.location_TransactionsAcceleratorToolServiceRoot + "AcceleratorToolTransactionsExport";
    location_PrepareAcceleratorTool: string = this.location_TransactionsAcceleratorToolServiceRoot + "PrepareAcceleratorTool";
    location_ProcessAcceleratorTool: string = this.location_TransactionsAcceleratorToolServiceRoot + "ProcessAcceleratorTool";


    location_TransactionsGenerosityToolServiceRoot: string = appGlobals.WebServiceURL + "/TransactionGenerosityToolService/";
    location_GenerosityToolTransactionsList: string = this.location_TransactionsGenerosityToolServiceRoot + "GenerosityToolTransactionsList";
    location_GenerosityToolTransactionsExport: string = this.location_TransactionsGenerosityToolServiceRoot + "GenerosityToolTransactionsExport";

    location_TransactionsGrowthServiceRoot: string = appGlobals.WebServiceURL + "/TransactionGrowthService/";
    location_AccountGrowthTransactions: string = this.location_TransactionsGrowthServiceRoot + "AccountGrowthTransactionsList";
    location_AccountGrowthTransactionsExport: string = this.location_TransactionsGrowthServiceRoot + "AccountGrowthTransactionsExport";
    location_GrowthTransactionsMonths: string = this.location_TransactionsGrowthServiceRoot + "GrowthTransactionsMonths";

    location_TransactionsAccountFeesServiceRoot: string = appGlobals.WebServiceURL + "/TransactionAccountFeesService/";
    location_AccountSummaryBrandNames: string = this.location_TransactionsAccountFeesServiceRoot + "AccountSummaryBrandNames";
    location_AccountFeesSummaryList: string = this.location_TransactionsAccountFeesServiceRoot + "AccountFeesSummaryList";
    location_AccountFeesSummaryExport: string = this.location_TransactionsAccountFeesServiceRoot + "AccountFeesSummaryExport";
    location_AccountFeesTransactionsList: string = this.location_TransactionsAccountFeesServiceRoot + "AccountFeesTransactionsList";
    location_AccountFeesTransactionsExport: string = this.location_TransactionsAccountFeesServiceRoot + "AccountFeesTransactionsExport";
    location_BrandNamesMonths: string = this.location_TransactionsAccountFeesServiceRoot + "AccountBrandNamesMonths";
    location_AccountFeeTypes: string = this.location_TransactionsAccountFeesServiceRoot + "AccountFeeTypes";
    location_FeesTransactionsMonths: string = this.location_TransactionsAccountFeesServiceRoot + "FeesTransactionsMonths";

    SpendingToolSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        VendorId: number, datefrom: Date, dateto: Date, dateselection: string): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            VendorId: VendorId,
            DateFrom: datefrom,
            DateTo: dateto,
            DateSelection: dateselection
        };
        return this.api.ServiceBase_Execute(this.location_SpendingToolSummaryList, requestData);
    }

    SpendingToolSummary_Export(orderField: string, orderDirection: string,
        VendorId: number, datefrom: Date, dateto: Date, dateselection: string): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            VendorId: VendorId,
            DateFrom: datefrom,
            DateTo: dateto,
            DateSelection: dateselection
        };
        return this.api.ServiceBase_Execute(this.location_SpendingToolSummaryExport, requestData);
    }

    SpendingVendorMonths_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_SpendingVendorMonths, requestData);
    }

    SpendingVendors_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_SpendingVendors, requestData);
    }

    SpendingToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        VendorId: number, searchcriteria: string, datefrom: Date, dateto: Date, dateselection: string): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            VendorId: VendorId,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto,
            DateSelection: dateselection
        };
        return this.api.ServiceBase_Execute(this.location_SpendingToolTransactionsList, requestData);
    }

    SpendingToolTransactions_Export(orderField: string, orderDirection: string,
        VendorId: number, searchcriteria: string, datefrom: Date, dateto: Date, dateselection: string): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            VendorId: VendorId,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto,
            DateSelection: dateselection
        };
        return this.api.ServiceBase_Execute(this.location_SpendingToolTransactionsExport, requestData);
    }

    AcceleratorToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_AcceleratorToolTransactionsList, requestData);
    }

    AcceleratorToolTransactions_Export(orderField: string, orderDirection: string,
        searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AcceleratorToolTransactionsExport, requestData);
    }

    GenerosityToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_GenerosityToolTransactionsList, requestData);
    }

    GenerosityToolTransactions_Export(orderField: string, orderDirection: string,
        searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_GenerosityToolTransactionsExport, requestData);
    }

    ValueToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
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
        return this.api.ServiceBase_Execute(this.location_ValueToolTransactionsList, requestData);
    }

    ValueToolTransactions_Export(orderField: string, orderDirection: string,
        searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_ValueToolTransactionsExport, requestData);
    }

    AccountSummaryBrandNames_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_AccountSummaryBrandNames, requestData);
    }

    BrandNamesMonths_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_BrandNamesMonths, requestData);
    }
    AccountFeesSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        brandname: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeesSummaryList, requestData);
    }

    AccountFeesSummary_Export(orderField: string, orderDirection: string,
        brandname: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeesSummaryExport, requestData);
    }

    AccountFeeTypes_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeeTypes, requestData);
    }

    FeesTransactionsMonths_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_FeesTransactionsMonths, requestData);
    }

    AccountFeesTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        brandname: string, feetype: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            FeeType: feetype,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeesTransactionsList, requestData);
    }

    AccountFeesTransactions_Export(orderField: string, orderDirection: string,
        brandname: string, feetype: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            FeeType: feetype,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountFeesTransactionsExport, requestData);
    }

    GrowthTransactionsMonths_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_GrowthTransactionsMonths, requestData);
    }

    AccountGrowthTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        brandname: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountGrowthTransactions, requestData);
    }

    AccountGrowthTransactions_Export(orderField: string, orderDirection: string,
        brandname: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            BrandName: brandname,
            SearchCriteria: searchcriteria,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_AccountGrowthTransactionsExport, requestData);
    }

    MonthlyTransactionSummaryMonths_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_MonthlyTransactionSummaryMonths, requestData);
    }

    MonthlyTransactionSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
        datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: pageSize,
            PageNumber: pageNumber,
            OrderField: orderField,
            OrderDirection: orderDirection,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_MonthlyTransactionSummaryList, requestData);
    }

    MonthlyTransactionSummary_Export(orderField: string, orderDirection: string,
        datefrom: Date, dateto: Date): any {
        var requestData = {
            PageSize: 0,
            PageNumber: 0,
            OrderField: orderField,
            OrderDirection: orderDirection,
            DateFrom: datefrom,
            DateTo: dateto
        };
        return this.api.ServiceBase_Execute(this.location_MonthlyTransactionSummaryExport, requestData);
    }

    PrepareAcceleratorTool_GetTransactions(Filename: string, DebitOrderDate: Date): any {
        var requestData = {
            fileName: Filename,
            debitOrderDate: DebitOrderDate
        };
        return this.api.ServiceBase_Execute(this.location_PrepareAcceleratorTool, requestData);
    }

    ProcessAcceleratorTool_Write(filePath: string, DebitOrderDate: Date): any {
        var requestData = {
            fileName: filePath,
            debitOrderDate: DebitOrderDate
        };
        return this.api.ServiceBase_Execute(this.location_ProcessAcceleratorTool, requestData);
    }

    Vendors_Get(): any {
        var requestData = {
        };
        return this.api.ServiceBase_Execute(this.location_GetVendors, requestData);
    }

    SpendingPartner_Process(vendorId: number, filePath: string): any {
        var requestData = {
            VendorId: vendorId,
            FileName: filePath
        };
        return this.api.ServiceBase_Execute(this.location_ProcessAcceleratorTool, requestData);
    }



}
