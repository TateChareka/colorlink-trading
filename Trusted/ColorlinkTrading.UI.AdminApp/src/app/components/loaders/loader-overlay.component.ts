import {
    Component, EventEmitter,
    Input, Output
} from '@angular/core';
import * as appGlobals from '../../app-globals';

@Component({
    selector: 'loader-overlay',
    templateUrl: './loader-overlay.component.html',
    styleUrls: ['./loader-overlay.component.css']
})

export class LoaderOverlayComponent {

    constructor() {

    }

    getControlVisible() { 
        return appGlobals.ui_GlobalLoaderVisible;
    }

}
