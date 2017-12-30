var VERSION = "2.0";
var APIBaseURL = window.location.protocol + '//' + window.location.host; //"http://localhost:27460";
var HeaderData = { "lpcUref": "f9fb42cf-4696-4b82-9657-07c9e006464d", "SignInEnvironment": "MobileApp" };       //live
//var HeaderData = { "lpcUref": "ccfc2bde-09fb-47b2-9d4c-41296c8531ef", "SignInEnvironment": "MobileApp" };       //local

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
    //                                   MOBILE APP FUNCTIONS                                                   //
    //----------------------------------------------------------------------------------------------------------//

    //AUTHENTICATION
    //:sign in / sign in from cache - app user
    {
        comments: "Sign User In",
        url: "AppService/SignIn",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",

            UserEmail: 'johnjones@softiceit.co.za',
            UserPassword: '12345',
            UserAuthenticationGUID: '',
            SignInEnvironment: 'MobileApp'
        }
    },
    {
        comments: "Sign User In",
        url: "AppService/SignUp",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",

            AppUserInfo: {
                AppUserGUID: "",
                FirstName: "John",
                LastName: "Jones",
                EmailAddress: "johnjones@softiceit.co.za",
                MobileNumber: "",
                Password: "12345",
                ConfirmPassword: "12345"
            }
        }
    },
    {
        comments: "Update User Profile",
        url: "AppService/Write",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",

            AppUserInfo: {
                AppUserGUID: "f9fb42cf-4696-4b82-9657-07c9e006464d",
                FirstName: "John",
                LastName: "Jones",
                EmailAddress: "johnjones@softiceit.co.za",
                MobileNumber: "",
                NotificationTime: "08:00",
                Password: "",
                ConfirmPassword: ""
            }
        }
    }, {
        comments: "Get the course bundle list",
        url: "AppService/CourseBundleList",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion"
        }
    },
    {
        comments: "Get the course bundle list",
        url: "AppService/CourseItemList",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion"
        }
    },
    {
        comments: "Get the course bundle list",
        url: "AppService/DownloadCourse",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",
            ItemID: 5
        }
    },
    {
        comments: "Initiate a support request",
        url: "AppService/SupportRequest",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",
            "QuerySubject": "Support Query Subject",
            "QueryMessage": "Support Query Message"
        }
    },
    {
        comments: "Log Device Data",
        url: "AppService/LogDeviceData",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion",
            LogCourseItems: [
                {
                    ID: 1,
                    UserIdentifier: "12345",
                    CourseItemId: 1,
                    Completed: 0,
                    DateStarted: "1 May 2017 12:06",
                    LastDayCompleted: 5,
                    DateCompleted: "2 May 2017 13:05",
                    LocalDateStarted: 3,
                    LocalDateCompleted: 5
                }
            ],
            LogCourseDays: [
                {
                    ID: 1,
                    UserIdentifier: "12345",
                    CourseBundleId: 1,
                    CourseDayId: 2,
                    NumberInBundle: 3,
                    LocalDateCompleted: 12,
                    Completed: 0
                }
            ],
            LogCourseDayItems: [
                {
                    ID: 1,
                    UserIdentifier: "12345",
                    CourseDayItemId: 6,
                    Action: "This is my action",
                    RecordDate: "3 May 2017 15:02:12"
                }
            ],
            UserNotes: [
                {
                    ID: 1,
                    UserIdentifier: "12345",
                    CourseDayItemId: 6,
                    NoteTitle: "Note Title",
                    NoteContent: "Note Content",
                    LocalRecordDate: 12,
                    RecordDate: '15 May 2017 15:03:27'
                }
            ]
        }
    },
    {
        comments: "Retrieve the data log for the user",
        url: "AppService/GetUserDataLog",
        dataToSend: {
            DeviceUUID: "deviceuuid",
            DeviceCordova: "devicecordova",
            DeviceModel: "devicemodel",
            DeviceVersion: "deviceversion",
            ApplicationVersion: "appversion"
        }   
    }
];