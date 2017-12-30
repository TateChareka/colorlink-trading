import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MaterialModule,
  MdNativeDateModule,
  MdTableModule,
  MdDatepickerModule,
  MdDialogModule,
  MdButtonModule,
  MdToolbarModule,
  MdCardModule,
  MdChipsModule,
  MdInputModule,
  MdGridListModule
} from '@angular/material';

import { APIServiceBase } from './services/api.servicebase';

import { APICommunicationsService } from './services/api.communications.service';
import { APICommunicationsProvider } from './providers/api.communications.provider';
import { APIMembersService } from './services/api.members.service';
import { APIMembersProvider } from './providers/api.members.provider';
import { APISpendingPartnerService } from './services/api.spendingpartners.service';
import { APISpendingPartnerProvider } from './providers/api.spendingpartners.provider';
import { APIFeesService } from './services/api.fees.service';
import { APIFeesProvider } from './providers/api.fees.provider';
import { APIMetricsService } from './services/api.metrics.service';
import { APIMetricsProvider } from './providers/api.metrics.provider';
import { APIGrowthService } from './services/api.growth.service';
import { APIGrowthProvider } from './providers/api.growths.provider';
import { APITransactionsService } from './services/api.transactions.service';
import { APITransactionsProvider } from './providers/api.transactions.provider';
import { APIEducationalInstitutionService } from './services/api.educationalinstitution.service';
import { APIEducationalInstitutionProvider } from './providers/api.educationalinstitution.provider';
import { APIEmployeesService } from './services/api.employees.service';
import { APIEmployeesProvider } from './providers/api.employees.provider';
import { APIMediaService } from './services/api.media.service';
import { APISystemUserService } from './services/api.systemuser.service';
import { APISystemUserProvider } from './providers/api.systemuser.provider';
import { APIUtilityService } from './services/api.utility.service';
import { APIUtilityProvider } from './providers/api.utility.provider';

import { AppComponent } from './app.component';

import { LoaderOverlayComponent } from './components/loaders/loader-overlay.component';
import { ModalGlobalComponent } from './components/modals/modal-global.component';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { ApplicationLoginComponent } from './components/app-login/app-login.component';

import { HtmlEditorComponent } from './components/editors/html-editor.component';
import { SafeHtmlFilter } from './pipes/safeHTML.filter';
import { GridTextHighlightPipe } from './pipes/gridTextHighlight.filter';

import { MembersListPage } from './pages/members/members-list.page';
import { NedbankFTPDownloadListPage } from './pages/members/nedbankftpdownload-list.page';
import { NedbankActivationStatusListPage } from './pages/members/nedbankactivationstatus-list.page';
import { DischemActivationStatusListPage } from './pages/members/dischemactivationstatus-list.page';
import { StatementRunsListPage } from './pages/members/statementruns-list.page';
import { AcceleratorListingsListPage } from './pages/members/acceleratorlistings-list.page';
import { AcceleratorItemListPage } from './pages/members/acceleratorlistings-item.page';
import { MemberStatementsListPage } from './pages/members/memberstatements-list.page';

import { SpendingToolSummaryListPage } from './pages/transactions/spendingtoolsummary-list.page';
import { SpendingToolTransactionsListPage } from './pages/transactions/spendingtooltransactions-list.page';
import { AcceleratorTransactionsListPage } from './pages/transactions/acceleratortransactions-list.page';
import { GenerosityTransactionsListPage } from './pages/transactions/generositytransactions-list.page';
import { ValueTransactionsListPage } from './pages/transactions/valuetransactions-list.page';
import { AccountFeesSummaryListPage } from './pages/transactions/accountfeessummary-list.page';
import { AccountFeeTransactionsListPage } from './pages/transactions/accountfeetransactions-list.page';
import { GrowthTransactionsListPage } from './pages/transactions/growthtransactions-list.page';
import { TransactionsSummaryListPage } from './pages/transactions/transactionssummary-list.page';
import { ProcessAcceleratorToolListPage } from './pages/transactions/processacceleratortool-list.page';
import { ProcessSpendingToolListPage } from './pages/transactions/processspendingtool-list.page';

import { CommMessagesListPage } from './pages/communications/communicationsmessages-list.page';
import { CommMessagesItemPage } from './pages/communications/communicationsmessages-item.page';
import { CommTypesListPage } from './pages/communications/communicationstypes-list.page';
import { CommTypesItemPage } from './pages/communications/communicationstypes-item.page';
import { CommTemplatesListPage } from './pages/communications/communicationstemplates-list.page';
import { CommTemplatesItemPage } from './pages/communications/communicationstemplates-item.page';
import { MessageLogsListPage } from './pages/communications/messagelogs-list.page';

import { SpendingPartnerListPage } from './pages/spendingpartners/spendingpartner-list.page';

import { MetricsListPage } from './pages/metrics/metrics-list.page';

import { AccountFeeListPage } from './pages/fees/accountfee-list.page';
import { AccountFeeItemPage } from './pages/fees/accountfee-item.page';

import { EducationalInstitutionListPage } from './pages/educationalinstitutions/educationalinstitution-list.page';
import { EducationalInstitutionItemPage } from './pages/educationalinstitutions/educationalinstitution-item.page';




//devexpress
import {
  DxDataGridModule, DxDateBoxModule, DxCheckBoxModule, DxTextBoxModule, DxButtonModule, DxSelectBoxModule,
  DxFormModule, DxChartModule, DxTextAreaModule, DxFileUploaderModule, DxResponsiveBoxModule, DxFilterBuilderModule, DxLoadPanelModule,
  DxPopupModule, DxValidationGroupModule, DxValidationSummaryModule, DxValidatorModule,
} from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent, LoaderOverlayComponent, ModalGlobalComponent, SafeHtmlFilter, GridTextHighlightPipe,
    MembersListPage, NedbankFTPDownloadListPage, NedbankActivationStatusListPage,
    StatementRunsListPage, AcceleratorListingsListPage, MemberStatementsListPage, DischemActivationStatusListPage,
    TopNavigationComponent, ApplicationLoginComponent, SpendingToolSummaryListPage, SpendingToolTransactionsListPage, AcceleratorTransactionsListPage,
    GenerosityTransactionsListPage, ValueTransactionsListPage, AccountFeesSummaryListPage, AccountFeeTransactionsListPage, GrowthTransactionsListPage,
    TransactionsSummaryListPage, CommMessagesListPage, CommTypesListPage, CommTemplatesListPage, MessageLogsListPage, SpendingPartnerListPage, AccountFeeListPage,
    EducationalInstitutionListPage, MetricsListPage, ProcessAcceleratorToolListPage, ProcessSpendingToolListPage,

    AccountFeeItemPage, AcceleratorItemListPage, CommTypesItemPage, CommTemplatesItemPage, EducationalInstitutionItemPage, CommMessagesItemPage

  ],
  imports: [
    routing, HttpModule, MaterialModule, MdNativeDateModule, MdTableModule, MdDatepickerModule, MdDialogModule, MdButtonModule, MdToolbarModule, MdCardModule,
    MdChipsModule, MdInputModule, MdGridListModule,
    BrowserModule, BrowserAnimationsModule, FormsModule,
    DxDataGridModule, DxChartModule, DxDateBoxModule, DxTextBoxModule,
    DxCheckBoxModule, DxButtonModule, DxSelectBoxModule, DxFormModule, DxLoadPanelModule,
    DxFileUploaderModule, DxResponsiveBoxModule, DxFilterBuilderModule, DxTextAreaModule, DxPopupModule,
    DxValidationGroupModule, DxValidationSummaryModule, DxValidatorModule
  ],
  providers: [APICommunicationsService, APICommunicationsProvider, APIMembersService, APIMembersProvider, APIMetricsService, APIMetricsProvider,
    APISystemUserService, APISystemUserProvider, APIUtilityService, APIUtilityProvider, APIMetricsService, APIMetricsProvider, APITransactionsService, APITransactionsProvider,
    APIServiceBase, APISpendingPartnerService, APISpendingPartnerProvider, APIFeesProvider, APIFeesService, APIGrowthService, APIGrowthProvider, APIEducationalInstitutionService, APIEducationalInstitutionProvider,
    APIEmployeesProvider, APIEmployeesService, APIMediaService,

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
