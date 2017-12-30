import { Component, ViewChild, ElementRef, AfterContentInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from '@angular/router';
import * as appGlobals from '../../app-globals';
import { APIMetricsProvider } from './../../providers/api.metrics.provider';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { APIUtilityProvider } from './../../providers/api.utility.provider';
import { GridTextHighlightPipe } from './../../pipes/gridTextHighlight.filter';
import { DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxLoadPanelModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';
import { ChangeDetectorRef } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'metrics-list',
  templateUrl: './metrics-list.page.html',
  styleUrls: ['./../../../theme/datagrid-toolbar.css']
})

export class MetricsListPage implements OnInit  {
  currentMonth: Date = new Date();
  DateFrom: Date = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth(), 1);
  DateTo: Date = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth(), 30);
  previousMonth1: Date = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 1, 1);
  previousMonth2: Date = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 2, 1);
  previousMonth3: Date = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 3, 1);
  showError: boolean = false;
  gridData: any = {};
  dataStore: any = {};
  metricMonthsList: any = [];

  constructor(private routeControl: Router, private apiProvider: APIMetricsProvider, private element: ElementRef,
    private cdRef : ChangeDetectorRef) {
    appGlobals.SetActivePageTitle("Metrics");

    if (!appGlobals.checkSignInCache()) {
      this.routeControl.navigate(['/' + appGlobals.LandingPage]);
    }
  }

  ngOnInit() {
    this.getMemberMetricMonths();
    this.getMetrics();
  }


  getMetrics() {
    var that = this;
    this.dataStore = new DataSource({
      load: function (loadOptions) {
        return that.apiProvider.MemberMetrics_Get(that.DateFrom, that.DateTo).then(
          (result: any) => {
            if (result.HasError) {
              throw "Data Load Error: " + result.Feedback;
            }
            return {
              data: result.MemberMetrics
            };
          },
          (error) => {
            throw "Data Load Error";
          });
      }
    });
    this.gridData = this.dataStore;
  }

  getMemberMetricMonths() {
    this.apiProvider.MemberMetricsMonths_Get().then(
      (result: any) => {
        if (result.HasError) {
          throw "Data Load Error: " + result.Feedback;
        }
        this.metricMonthsList = result.data;
      },
      (error) => {
        throw "Data Load Error";
      });
  }

  onToolbarPreparing(e) {
    e.toolbarOptions.items.unshift(
      {
        location: 'after',
        template: 'periodLabel'
      },
      {
        location: 'after',
        template: 'MonthsDropDown'
      });
  }


  formatDate(date) {
    var monthNames = [
      "January", "February", "March",
      "April", "May", "June", "July",
      "August", "September", "October",
      "November", "December"
    ];
    var monthIndex = date.getMonth();
    var year = date.getFullYear();
    return monthNames[monthIndex] + ' ' + year;
  }

  MetricMonthChanged($event) {
    this.currentMonth = new Date($event.value);
    this.DateFrom = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth(), 1);
    this.DateTo = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth(), 30);
    this.previousMonth1 = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 1, 1);
    this.previousMonth2 = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 2, 1);
    this.previousMonth3 = new Date(this.currentMonth.getFullYear(), this.currentMonth.getMonth() - 3, 1);
    this.getMetrics();
    this.cdRef.detectChanges();
  }
}