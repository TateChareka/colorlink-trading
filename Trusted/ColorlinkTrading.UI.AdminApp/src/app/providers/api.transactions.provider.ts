import { Injectable } from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { APITransactionsService } from '../services/api.transactions.service';
import { APIMediaService } from '../services/api.media.service';

@Injectable()
export class APITransactionsProvider {

	constructor(private apiService: APITransactionsService, private apiMediaService: APIMediaService) {
	}

	SpendingToolSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		VendorId: number, datefrom: Date, dateto: Date, dateselection: string): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingToolSummary_List(pageSize, pageNumber, orderField, orderDirection, VendorId, datefrom, dateto, dateselection).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingToolSummary_Export(orderField: string, orderDirection: string,
		VendorId: number, datefrom: Date, dateto: Date, dateselection: string): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingToolSummary_Export(orderField, orderDirection, VendorId, datefrom, dateto, dateselection).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingVendorMonths_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingVendorMonths_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingVendors_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingVendors_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		VendorId: number, searchcriteria: string, datefrom: Date, dateto: Date, dateselection: string): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingToolTransactions_List(pageSize, pageNumber, orderField, orderDirection, VendorId, searchcriteria, datefrom, dateto, dateselection).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingToolTransactions_Export(orderField: string, orderDirection: string,
		VendorId: number, searchcriteria: string, datefrom: Date, dateto: Date, dateselection: string): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingToolTransactions_Export(orderField, orderDirection, VendorId, searchcriteria, datefrom, dateto, dateselection).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AcceleratorToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AcceleratorToolTransactions_List(pageSize, pageNumber, orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AcceleratorToolTransactions_Export(orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AcceleratorToolTransactions_Export(orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	GenerosityToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.GenerosityToolTransactions_List(pageSize, pageNumber, orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	GenerosityToolTransactions_Export(orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.GenerosityToolTransactions_Export(orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	ValueToolTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.ValueToolTransactions_List(pageSize, pageNumber, orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	ValueToolTransactions_Export(orderField: string, orderDirection: string,
		searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.ValueToolTransactions_Export(orderField, orderDirection, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountSummaryBrandNames_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.AccountSummaryBrandNames_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	BrandNamesMonths_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.BrandNamesMonths_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}


	AccountFeesSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		brandname: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AccountFeesSummary_List(pageSize, pageNumber, orderField, orderDirection, brandname, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountFeesSummary_Export(orderField: string, orderDirection: string,
		brandname: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AccountFeesSummary_Export(orderField, orderDirection, brandname, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountFeeTypes_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.AccountFeeTypes_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	FeesTransactionsMonths_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.FeesTransactionsMonths_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountFeesTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		brandname: string, feetype: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AccountFeesTransactions_List(pageSize, pageNumber, orderField, orderDirection, brandname, feetype, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountFeesTransactions_Export(orderField: string, orderDirection: string,
		brandname: string, feetype: string, searchcriteria: string, datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.AccountFeesTransactions_Export(orderField, orderDirection, brandname, feetype, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	GrowthTransactionsMonths_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.GrowthTransactionsMonths_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountGrowthTransactions_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		brandname: string, searchcriteria: string, datefrom: Date, dateto: Date) {
		return new Promise((result, exception) => {
			this.apiService.AccountGrowthTransactions_List(pageSize, pageNumber, orderField, orderDirection, brandname, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	AccountGrowthTransactions_Export(orderField: string, orderDirection: string,
		brandname: string, searchcriteria: string, datefrom: Date, dateto: Date) {
		return new Promise((result, exception) => {
			this.apiService.AccountGrowthTransactions_Export(orderField, orderDirection, brandname, searchcriteria, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	MonthlyTransactionSummaryMonths_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.MonthlyTransactionSummaryMonths_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	MonthlyTransactionSummary_List(pageSize: number, pageNumber: number, orderField: string, orderDirection: string,
		datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.MonthlyTransactionSummary_List(pageSize, pageNumber, orderField, orderDirection, datefrom, dateto).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	MonthlyTransactionSummary_Export(orderField: string, orderDirection: string,
		datefrom: Date, dateto: Date): any {
		return new Promise((result, exception) => {
			this.apiService.MonthlyTransactionSummary_Export(orderField, orderDirection, datefrom, dateto).subscribe(
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

	PrepareAcceleratorTool_GetTransactions(Filename: string, DebitOrderDate: Date): any {
		return new Promise((result, exception) => {
			this.apiService.PrepareAcceleratorTool_GetTransactions(Filename, DebitOrderDate).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	ProcessAcceleratorTool_Write(filePath: string, DebitOrderDate: Date): any {
		return new Promise((result, exception) => {
			this.apiService.ProcessAcceleratorTool_Write(filePath, DebitOrderDate).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	Vendors_Get(): any {
		return new Promise((result, exception) => {
			this.apiService.Vendors_Get().subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

	SpendingPartner_Process(vendorId: number, filePath: string): any {
		return new Promise((result, exception) => {
			this.apiService.SpendingPartner_Process(vendorId, filePath).subscribe(
				response => {
					result(response);
				},
				error => { exception(error); });
		});
	}

}