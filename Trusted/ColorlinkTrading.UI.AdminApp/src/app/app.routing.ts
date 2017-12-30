import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

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
import { CommMessagesListPage } from './pages/communications/communicationsmessages-list.page';
import { CommMessagesItemPage } from './pages/communications/communicationsmessages-item.page';
import { CommTypesListPage } from './pages/communications/communicationstypes-list.page';
import { CommTypesItemPage } from './pages/communications/communicationstypes-item.page';
import { CommTemplatesListPage } from './pages/communications/communicationstemplates-list.page';
import { CommTemplatesItemPage } from './pages/communications/communicationstemplates-item.page';
import { MessageLogsListPage } from './pages/communications/messagelogs-list.page';
import { SpendingPartnerListPage } from './pages/spendingpartners/spendingpartner-list.page';
import { AccountFeeListPage } from './pages/fees/accountfee-list.page';
import { AccountFeeItemPage } from './pages/fees/accountfee-item.page';
import { EducationalInstitutionListPage } from './pages/educationalinstitutions/educationalinstitution-list.page';
import { EducationalInstitutionItemPage } from './pages/educationalinstitutions/educationalinstitution-item.page';
import { MetricsListPage } from './pages/metrics/metrics-list.page';
import { ProcessAcceleratorToolListPage } from './pages/transactions/processacceleratortool-list.page';
import { ProcessSpendingToolListPage } from './pages/transactions/processspendingtool-list.page';

const appRoutes: Routes = [
    {
        path: "",
        component: MetricsListPage
    },
    {
        path: "members-list",
        component: MembersListPage
    },
    {
        path: 'nedbankftpdownload-list',
        component: NedbankFTPDownloadListPage
    },
    {
        path: 'nedbankactivationstatus-list',
        component: NedbankActivationStatusListPage
    },
    {
        path: 'dischemactivationstatus-list',
        component: DischemActivationStatusListPage
    },
    {
        path: 'statementruns-list',
        component: StatementRunsListPage
    },
    {
        path: 'acceleratorlistings-list',
        component: AcceleratorListingsListPage
    },
    {
        path: 'memberstatements-list',
        component: MemberStatementsListPage
    },
    {
        path: 'spendingtoolsummary-list',
        component: SpendingToolSummaryListPage
    },
    {
        path: 'spendingtooltransactions-list',
        component: SpendingToolTransactionsListPage
    },
    {
        path: 'acceleratortransactions-list',
        component: AcceleratorTransactionsListPage
    },
    {
        path: 'generositytransactions-list',
        component: GenerosityTransactionsListPage
    },
    {
        path: 'valuetransactions-list',
        component: ValueTransactionsListPage
    },
    {
        path: 'accountfeessummary-list',
        component: AccountFeesSummaryListPage
    },
    {
        path: 'accountfeetransactions-list',
        component: AccountFeeTransactionsListPage
    },
    {
        path: 'growthtransactions-list',
        component: GrowthTransactionsListPage
    },
    {
        path: 'transactionssummary-list',
        component: TransactionsSummaryListPage
    },
    {
        path: "communicationsmessages-list",
        component: CommMessagesListPage
    },
    {
        path: "communicationstemplates-list",
        component: CommTemplatesListPage
    },
    {
        path: "communicationstypes-list",
        component: CommTypesListPage
    },
    {
        path: "messagelogs-list",
        component: MessageLogsListPage
    },
    {
        path: "spendingpartner-list",
        component: SpendingPartnerListPage
    },
    {
        path: "accountfee-list",
        component: AccountFeeListPage
    },
    {
        path: "accountfee-item",
        component: AccountFeeItemPage
    },
    {
        path: "educationalinstitution-list",
        component: EducationalInstitutionListPage
    },
    {
        path: "educationalinstitution-item",
        component: EducationalInstitutionItemPage
    },
    {
        path: "acceleratorlistings-item",
        component: AcceleratorItemListPage
    },
    {
        path: "communicationstypes-item",
        component: CommTypesItemPage
    },
    {
        path: "communicationstemplates-item",
        component: CommTemplatesItemPage
    },
    {
        path: "communicationsmessages-item",
        component: CommMessagesItemPage
    },
    {
        path: "metrics-list",
        component: MetricsListPage
    },
    {
        path: "processacceleratortool-list",
        component: ProcessAcceleratorToolListPage
    },
    {
        path: "processspendingtool-list",
        component: ProcessSpendingToolListPage
    },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);