import { NgModule, Component, ViewChild, ElementRef, AfterContentInit, OnInit, AfterViewInit, enableProdMode } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute, Params } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIEducationalInstitutionProvider } from './../../providers/api.educationalinstitution.provider';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';

import { DxDataGridModule, DxSelectBoxModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxFormModule, DxFormComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'educationalinstitution-item',
  templateUrl: './educationalinstitution-item.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class EducationalInstitutionItemPage {
  CurrentDate = new Date().toDateString();
  minDate: Date = new Date();
  currentRecordId: number = 0;
  GradesList: any = [];
  ProvincesList: any = [];
  focustItem: any = {
    "AccountType": "",
    "BankName": "",
    "BankAccountName": "",
    "BankAccountNo": "",
    "BranchCode": "",
    "EducationalInstitutionId": "",
    "EducationalInstitutionName": "",
    "EducationDepartmentRegNo": "",
    "FinishGradeId": "",
    "SchoolAccountsDeptEmail": "",
    "SchoolLocationAddressLine1": "",
    "SchoolLocationAddressLine2": "",
    "SchoolLocationCityorTown": "",
    "SchoolLocationLatitude": "",
    "SchoolLocationLongitude": "",
    "SchoolLocationPostalCode": "",
    "SchoolLocationProvinceId": "",
    "SchoolPrimaryContactPerson": "",
    "SchoolPrimaryContactPersonRole": "",
    "SchoolPrimaryContactPersonTitle": "",
    "SchoolsContactTelephone": "",
    "SchoolSecondContactPerson": "",
    "StartGradeId": "",
    "UpdatedByUserName": "",
    "UpdatedDate": "",
    "CreatedDate": "",
    "CreatedByUserName": ""
  };

  constructor(private routeControl: Router, private apiProvider: APIEducationalInstitutionProvider, private apiUtility: APIUtilityProvider, private activatedRoute: ActivatedRoute) {
    appGlobals.SetActivePageTitle("Educational Institution");
    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let ref = params['ref'];
      this.currentRecordId = 0;
      if (ref) {
        this.currentRecordId = parseInt(ref);
      }
      this.initData();
    });
  }

  initData() {
    this.GetGrades();
  }

  GetItemData() {
    if (this.currentRecordId != 0) {
      this.apiProvider.EducationalInstitutionItem_Get(this.currentRecordId).then(
        (result: any) => {
          if (result.HasError) {
            throw "Data Load Error: " + result.Feedback;
          }
          else {
            this.focustItem = result;
          }
        },
        (error) => {
          throw "Data Load Error";
        });
    }
  }

  GetGrades() {
    this.GradesList = [
      {
        value: "RRR"
      },
      {
        value: "RR"
      },
      {
        value: "R"
      },
      {
        value: "1"
      },
      {
        value: "2"
      },
      {
        value: "3"
      },
      {
        value: "4"
      },
      {
        value: "5"
      },
      {
        value: "6"
      },
      {
        value: "7"
      },
      {
        value: "8"
      },
      {
        value: "9"
      },
      {
        value: "10"
      },
      {
        value: "11"
      },
      {
        value: "12"
      },
      {
        value: "1st Year"
      },
      {
        value: "2nd Year"
      },
      {
        value: "3rd Year"
      }
    ];
    this.GetProvinces();
  }

  GetProvinces() {
    this.ProvincesList = [
      {
        value: "EasternCape",
        text: "Eastern Cape"
      },
      {
        value: "KwazuluNatal",
        text: "KwaZulu-Natal"
      },
      {
        value: "WesternCape",
        text: "Western Cape"
      },
      {
        value: "Gauteng",
        text: "Gauteng"
      },
      {
        value: "FreeState",
        text: "Free State"
      },
      {
        value: "Limpopo",
        text: "Limpopo"
      },
      {
        value: "Mpumalanga",
        text: "Mpumalanga"
      },
      {
        value: "NorthWest",
        text: "North West"
      },
      {
        value: "NorthernCape",
        text: "Northern Cape"
      }
    ];
    this.GetItemData();
  }



  CancelSave() {
    this.routeControl.navigate(["educationalinstitution-list"]);
  }

  SaveRecord($event) {
    // this.apiProvider.EducationalInstitution_Write(this.focustItem).then(
    //   (result: any) => {
    //     if (result.HasError) {
    //       throw "Data Load Error: " + result.Feedback;
    //     }
    //     else {
    //       appGlobals.ShowToastNotification(result.Feedback, "Success");
    //       this.routeControl.navigate(["educationalinstitution-list"]);

    //     }
    //   },
    //   (error) => {
    //     throw "Data Load Error";
    //   });
    $event.preventDefault();
  }

  formatDateColumn(cellInfo) {
    return appGlobals.GetStringDateGenericFromJSON(cellInfo, false, true, true, true, false);
  }

}