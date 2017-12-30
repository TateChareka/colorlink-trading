var VERSION = "1.0";
var APIBaseURL = window.location.protocol + '//' + window.location.host; //"http://localhost:27460";
var HeaderData = { "lpcUref": "2c29035f-10ee-4be8-8d93-8514d84bde3c", "SignInEnvironment": "Administration" };


//Use dateString if dates need to be sent
var date = new Date();
var dateString = date.getDay() + "-" + date.getMonth() + "-" + date.getFullYear();

var testData = [

    {
        comments: "Gets a list of test items",
        url: "Test/GetTestItems",
        dataToSend: {
            ShowInactive: true
        }
    },

    {
        comments: "Add a Test item",
        url: "Test/AddTestItem",
        dataToSend: {
            ItemID: 0,
            ItemName: "My New Item",
            IsActive: true
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                     SECURITY FUNCTIONS                                                   //
    //----------------------------------------------------------------------------------------------------------//

    //AUTHENTICATION
    //:sign in / sign in from cache - admin user
    {
        comments: "Sign User In",
        url: "SystemUserService/SignIn",
        dataToSend: {
            UserIdentifier: 'EDU-0000-4404',
            UserPassword: '@Liverpo0lFC',
            UserAuthenticationGUID: '',
            SignInEnvironment: 'Administration'
        }
    },
    //:reset user password
    {
        comments: "Reset an Administrative User Password",
        url: "AdminUserService/SetPassword",
        dataToSend: {
            UserAuthenticationGUID: 'e497aaf8-1bbf-4002-9a7c-4ece80a1e890',
            Password: 'TruBlue_52',
            ConfirmPassword: 'TruBlue_52'
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                      UTILITY FUNCTIONS                                                   //
    //----------------------------------------------------------------------------------------------------------//

    //:get period dates
    {
        comments: "Get Period Dates",
        url: "UtilityService/GetPeriodDates",
        dataToSend: {
            Period: 'LastWeek'
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                    MAIL FETCH FUNCTIONS                                                   //
    //----------------------------------------------------------------------------------------------------------//
    {
        comments: "Get Emails",
        url: "CommunicationsService/GetEmails",
        dataToSend: {
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                        FEES FUNCTIONS                                                    //
    //----------------------------------------------------------------------------------------------------------//

    {
        comments: "Get Account Fees",
        url: "FeeService/ProcessAccountFees",
        dataToSend: {
            SearchCriteria: '',
            DateFrom: '1 Sep 2014',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'FeeProcessDate',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Account Fee Item",
        url: "FeeService/GetAccountFeesItem",
        dataToSend: {
            ItemId: ''
        }
    },
     {
         comments: "Get Account Fee Models",
         url: "FeeService/GetAccountFeeModels",
         dataToSend: {

         }
     },
    //----------------------------------------------------------------------------------------------------------//
    //                                  COMMUNICATION FUNCTIONS                                                 //
    //----------------------------------------------------------------------------------------------------------//
    {
        comments: "Get the Communication Messages",
        url: "CommunicationsService/CommunicationsMessageSearch",
        dataToSend: {
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CommunicationMessageId',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get the Communication Messages",
        url: "CommunicationsService/CommunicationsTemplateSearch",
        dataToSend: {
            DateFrom: '1 Sep 2010',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            BrandName: '',
            OrderField: 'CommunicationTypeId',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get the Communication Messages",
        url: "CommunicationsService/CommunicationsTypesSearch",
        dataToSend: {
            DateFrom: '1 Sep 2010',
            DateTo: '19 Sep 2017',
            BrandName: '',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CommunicationTypeId',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get the Communication Type Brand Names",
        url: "CommunicationsService/GetCommunicationTypesBrandName",
        dataToSend: {

        }
    },
    {
        comments: "Get the Communication Message Item",
        url: "CommunicationsService/GetCommunicationMessageItem",
        dataToSend: {
            ItemId: '5'
        }
    },
    {
        comments: "Get Communication Type Item",
        url: "CommunicationsService/GetCommunicationTypeItem",
        dataToSend: {
            ItemId: ''
        }
    },
    {
        comments: "Get the Communication Template Brand Names",
        url: "CommunicationsService/GetCommunicationTemplateBrandName",
        dataToSend: {

        }
    },
    {
        comments: "Get the Communication Template Communication Type",
        url: "CommunicationsService/GetCommunicationTypes",
        dataToSend: {

        }
    },
    {
        comments: "Get Communication Template Item",
        url: "CommunicationsService/GetCommunicationTemplateItem",
        dataToSend: {
            ItemId: ''
        }
    },

    //----------------------------------------------------------------------------------------------------------//
    //                                   SPENDING PARTNERS FUNCTIONS                                            //
    //----------------------------------------------------------------------------------------------------------//

    {
        comments: "Search Member List",
        url: "SpendingPartnerService/SpendingPartnerSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2013',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'VendorId',
            OrderDirection: 'ASC'
        }
    },

    //----------------------------------------------------------------------------------------------------------//
    //                                          MEMBER FUNCTIONS                                                //
    //----------------------------------------------------------------------------------------------------------//

    {
        comments: "Search Nedbank Download for FTP Transmission List",
        url: "MemberService/NedbankDownloadForFTPTransmissionSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Search Nedbank Activation Status List",
        url: "MemberService/NedbankActivationStatusSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Search Dischem Activation Status List",
        url: "MemberService/DischemActivationStatusSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Search Statement Runs List",
        url: "MemberService/StatementRunsSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'StatementRunId',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Search Accelerator Listings List",
        url: "MemberService/AcceleratorListingsSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Search Member Statement List",
        url: "MemberService/MemberStatementsSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Disable Member Communications",
        url: "MemberService/DisableCommunications",
        dataToSend: {
            MemberAccountId: '1'
        }
    },
    {
        comments: "Enable Member Communications",
        url: "MemberService/EnableCommunications",
        dataToSend: {
            MemberAccountId: '1'
        }
    },
    {
        comments: "Delete Customer",
        url: "MemberService/DeleteMember",
        dataToSend: {
            MemberId: '1'
        }
    },
    {
        comments: "Search Member List",
        url: "MemberService/MemberSearch",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Export Filtered Member List",
        url: "MemberService/MemberExport",
        dataToSend: {
            SearchCriteria: 'Ian',
            DateFrom: '1 Sep 2017',
            DateTo: '19 Sep 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                     METRICS FUNCTIONS                                                    //
    //----------------------------------------------------------------------------------------------------------//
    {
        comments: "Get the Member Metrics",
        url: "MetricsService/Members",
        dataToSend: {
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get the Communications Metrics",
        url: "MetricsService/Communications",
        dataToSend: {
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'CardNumber',
            OrderDirection: 'ASC'
        }
    },
    //----------------------------------------------------------------------------------------------------------//
    //                                       TRANSACTION FUNCTIONS                                              //
    //----------------------------------------------------------------------------------------------------------//

    {
        comments: "Get the summary of transactions",
        url: "TransactionService/SpendingToolSummaryList",
        dataToSend: {
            VendorId: '0',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'SpendMonth',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Spending Vendor Months",
        url: "TransactionService/SpendingVendorMonths",
        dataToSend: {

        }
    },
    {
        comments: "Get Spending Vendors",
        url: "TransactionService/SpendingVendors",
        dataToSend: {

        }
    },
    {
        comments: "Get Accelerator Tools",
        url: "TransactionAcceleratorToolService/PrepareAcceleratorTool",
        dataToSend: {
            fileName: 'C:/Users/Tatenda Chareka/Desktop/Snips/20171204UPLOADV1_201712041233.xlsx',
            DateFrom: 'January 2014',
        }
    },
    {
        comments: "Get Spending Tool Transactions",
        url: "TransactionService/SpendingToolTransactionsList",
        dataToSend: {
            VendorId: '0',
            SearchCriteria: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'TransactionDateTime',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Accelerator Tool Transactions",
        url: "TransactionService/AcceleratorToolTransactionsList",
        dataToSend: {
            SearchCriteria: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'TransactionDateTime',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Generosity Tool Transactions",
        url: "TransactionService/GenerosityToolTransactionsList",
        dataToSend: {
            SearchCriteria: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'TransactionDateTime',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Value Tool Transactions",
        url: "TransactionService/ValueToolTransactionsList",
        dataToSend: {
            SearchCriteria: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'TransactionDateTime',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Brand Names",
        url: "TransactionService/AccountSummaryBrandNames",
        dataToSend: {

        }
    },
    {
        comments: "Get Brand Names Months",
        url: "TransactionService/AccountBrandNamesMonths",
        dataToSend: {

        }
    },
    {
        comments: "Get the summary of account fees",
        url: "TransactionService/AccountFeesSummaryList",
        dataToSend: {
            BrandName: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'FeeProcessMonth',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Account Fee Types",
        url: "TransactionService/AccountFeeTypes",
        dataToSend: {

        }
    },
    {
        comments: "Get Account Fee Transaction Months",
        url: "TransactionService/FeesTransactionsMonths",
        dataToSend: {

        }
    },
    {
        comments: "Get the account fees transactions",
        url: "TransactionService/AccountFeesTransactionsList",
        dataToSend: {
            SearchCriteria: '',
            BrandName: '',
            FeeType: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'FeeProcessDate',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Account Growth Transaction Months",
        url: "TransactionService/GrowthTransactionsMonths",
        dataToSend: {

        }
    },
    {
        comments: "Get the account growth transactions",
        url: "TransactionService/AccountGrowthTransactionsList",
        dataToSend: {
            SearchCriteria: '',
            BrandName: '',
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'GrowthProcessDate',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get the Monthly Transaction Summary",
        url: "TransactionService/MonthlyTransactionSummaryList",
        dataToSend: {
            DateFrom: 'January 2014',
            DateTo: 'July 2017',
            PageSize: '50',
            PageNumber: '1',
            OrderField: 'TransactionDateTime',
            OrderDirection: 'ASC'
        }
    },
    {
        comments: "Get Monthly Transaction Summary Months",
        url: "TransactionService/MonthlyTransactionSummaryMonths",
        dataToSend: {

        }
    },


];