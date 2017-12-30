import { Headers } from '@angular/http';
import { APICommunicationsProvider } from './providers/api.communications.provider';
import { APITransactionsProvider } from './providers/api.transactions.provider';
import notify from 'devextreme/ui/notify';

import { environment } from '../environments/environment';
'use strict';

export var WebServiceURL: string = environment.apiUrl;
export var api_Location_UploadFile: string = WebServiceURL + "/MediaService/UploadFileUsingIdentifier";

export var ActivePageTitle: string = "Page Title";
export function SetActivePageTitle(title: string) {
    ActivePageTitle = title;
}

export function GetAdminHeaders(): Headers {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('lpcUref', GetLocalCacheValue());
    headers.append('SignInEnvironment', 'Administration');
    return headers;
}

export var UserIsSignedIn: boolean = false;
export function SignUserIn() {
    UserIsSignedIn = true;
}

export var auth_LocalStorageAddress: string = "sd-admin-987";
export function SetLocalCacheValue(value: string) {
    window.localStorage.setItem(auth_LocalStorageAddress, value);
}
export function GetLocalCacheValue() {
    return window.localStorage.getItem(auth_LocalStorageAddress);
}
export function RemoveLocalCacheValue() {
    return window.localStorage.removeItem(auth_LocalStorageAddress);
}
export function HasLocalCacheValue() {
    if (window.localStorage.getItem(auth_LocalStorageAddress)) {
        return true;
    }
    else {
        return false;
    }
}
export function checkSignInCache() {
    return UserIsSignedIn;
}


export var LandingPage: string = "";

export var ui_GlobalLoaderVisible: boolean = false;

export function ShowGlobalLoader() {
    ui_GlobalLoaderVisible = true;
}

export function HideGlobalLoader() {
    ui_GlobalLoaderVisible = false;
}

export var ui_GlobalModalVisible: boolean = false;
export var ui_GlobalModalContent: string = "";
export var ui_GlobalModalTitle: string = "";
export var ui_GlobalModalIcon: string = "";

export function ShowGlobalModal(title: string, message: string, icon: string) {
    ui_GlobalModalTitle = title;
    ui_GlobalModalContent = message;
    ui_GlobalModalIcon = icon;
    ui_GlobalModalVisible = true;
}

export function ShowToastNotification(message: string, MessageType: string) {
    if (MessageType == "Success") {
        notify(message, MessageType, 1000);
    } if (MessageType == "Error") {
        ShowGlobalModal("Error", message, "Error");
    } else {
        notify(message, MessageType, 5000);
    }

}

export function HideGlobalModal() {
    ui_GlobalModalVisible = false;
}

export function ValidateForm(validationSetup: any, data: any) {
    var result = { "valid": true, "messages": [] };
    for (var v = 0; v < validationSetup.fields.length; v++) {
        if (data[validationSetup.fields[v]] == "") {
            result.valid = false;
            result.messages.push(validationSetup.messages[v]);
        }
    }
    return result;
}


export var tools_MonthArray: any = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
export var tools_MonthNameArray: any = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

export function GetStringDateGeneric(date: Date, showTime: boolean, showDay: boolean, showMonth: boolean, showYear: boolean, fullMonth: boolean) {
    var result = "";
    var theDay = date.getDate();
    var theMonth;
    if (fullMonth) {
        theMonth = tools_MonthNameArray[date.getMonth()];
    } else {
        theMonth = tools_MonthArray[date.getMonth()];
    }
    var theYear = date.getFullYear();
    if (showDay) {
        result += theDay + " ";
    }
    if (showMonth) {
        result += theMonth + " ";
    }
    if (showYear) {
        result += theYear + " ";
    }
    if (showTime) {
        var theHour = date.getHours().toString();
        var theMinute = date.getMinutes().toString();
        if (theHour.length == 1) {
            theHour = "0" + theHour;
        }
        if (theMinute.length == 1) {
            theMinute = "0" + theMinute;
        }
        result = result + " " + theHour + ":" + theMinute;
    }
    return result;
}

export function GetStringDateGenericFromJSON(jsonDate: string, showTime: boolean, showDay: boolean, showMonth: boolean, showYear: boolean, fullMonth: boolean) {
    if (jsonDate == null) {
        return "";
    }
    var re = /-?\d+/;
    var m = re.exec(jsonDate);
    var d = new Date(parseInt(m[0]));
    return GetStringDateGeneric(d, showTime, showDay, showMonth, showYear, fullMonth);
}

export function GetStandardPeriodDropDownItems() {
    var res = [
        {
            value: "Today",
            text: "Today"
        },
        {
            value: "Yesterday",
            text: "Yesterday"
        },
        {
            value: "ThisWeek",
            text: "This Week"
        },
        {
            value: "LastWeek",
            text: "Last Week"
        },
        {
            value: "ThisMonth",
            text: "This Month"
        },
        {
            value: "LastMonth",
            text: "Last Month"
        },
        {
            value: "ThisQuarter",
            text: "This Quarter"
        },
        {
            value: "LastQuarter",
            text: "Last Quarter"
        },
        {
            value: "All",
            text: "All"
        }
    ];
    return res;
}

export function ConvertFilterBuilderObjectModel(filter: any): any {
    if (filter == null) {
        return null;
    }
    var res = GetFilterGroup(filter);
    return res;
}

export function GetFilterGroup(filter: any): any {
    var res = {
        FilterGroup: {
            GroupItems: [],
            GroupOperator: "And",
            GroupGroups: []
        }
    }
    //does the parent have an array of values or an array of arrays
    var hasArrays = false;
    for (var i = 0; i < filter.length; i++) {
        if (Array.isArray(filter[i])) {
            hasArrays = true;
            break;
        }
    }
    if (hasArrays) {
        //is the first item a NOT
        var isNot = false;
        if (!Array.isArray(filter[0])) {
            if (filter[0] == "!") {
                isNot = true;
            }
        }
        if (!isNot) {
            for (var i = 0; i < filter.length; i++) {
                if (Array.isArray(filter[i])) {
                    var items = GetGroupItems(filter[i]);
                    for (var j = 0; j < items.length; j++) {
                        res.FilterGroup.GroupItems.push(items[j]);
                    }
                    res.FilterGroup.GroupGroups = GetGroupGroups(filter[i]);
                }
                else {
                    res.FilterGroup.GroupOperator = filter[i];
                }
            }
        }
        if (isNot) {
            for (var i = 0; i < filter[1].length; i++) {
                if (Array.isArray(filter[1][i])) {
                    var items = GetGroupItems(filter[1][i]);
                    for (var j = 0; j < items.length; j++) {
                        res.FilterGroup.GroupItems.push(items[j]);
                    }
                    res.FilterGroup.GroupGroups = GetGroupGroups(filter[1][i]);
                }
                else {
                    res.FilterGroup.GroupOperator = filter[1][i];
                }
            }
        }
        if (isNot) {
            res.FilterGroup.GroupOperator = "Not " + res.FilterGroup.GroupOperator;
        }
    }
    else {
        var item = {
            "FieldName": filter[0],
            "OperatorName": filter[1],
            "CriteriaValue": filter[2],
            "FiledDataType": filter[3]
        };
        res.FilterGroup.GroupItems.push(item);
    }
    return res;
}
export function GetGroupItems(filter: any): any {
    var res = [];
    var hasArrays = false;
    for (var i = 0; i < filter.length; i++) {
        if (Array.isArray(filter[i])) {
            hasArrays = true;
            break;
        }
    }
    if (!hasArrays) {
        var item = {
            "FieldName": filter[0],
            "OperatorName": filter[1],
            "CriteriaValue": filter[2],
            "FiledDataType": filter[3]
        };
        res.push(item);
    }
    return res;
}

export function GetGroupGroups(filter: any): any {

}