import {
    Component, EventEmitter,
    Input, Output
} from '@angular/core';
import * as appGlobals from '../../app-globals';

@Component({
    selector: 'modal-global',
    templateUrl: './modal-global.component.html',
    styleUrls: ['./modal-global.component.css']
})

export class ModalGlobalComponent {

    constructor() {

    }

    getControlVisible() { 
        return appGlobals.ui_GlobalModalVisible;
    }

    getControlContent() { 
        return appGlobals.ui_GlobalModalContent;
    }

    getControlTitle() { 
        return appGlobals.ui_GlobalModalTitle;
    }
    getControlIcon() { 
        return appGlobals.ui_GlobalModalIcon;
    }

    closeModal()
    {
        appGlobals.HideGlobalModal();
    }
}
