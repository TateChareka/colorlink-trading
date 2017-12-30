import {
    Component,
    OnDestroy,
    AfterViewInit,
    EventEmitter,
    Input,
    Output
} from '@angular/core';

import * as appGlobals from '../../app-globals';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'html-editor',
    templateUrl: './html-editor.component.html',
    styleUrls: ['./html-editor.component.css']
})

export class HtmlEditorComponent implements AfterViewInit, OnDestroy {

    @Input() elementId: String = "tinyEditor";
    @Input() editorTitle: String = "Edit Content";
    @Output() OnSaveContent : EventEmitter<any>  = new EventEmitter<any>(); 

    controlVisible:boolean = false;

    public Show(content:string)
    {   
       this.controlVisible = true;   
       this.editor.setContent(content); 
    }
 
    public Hide()
    {
        this.controlVisible = false;
    }
    
     saveContent()
     { 
        this.OnSaveContent.emit(tinymce.activeEditor.getContent());
        this.Hide();
     }

    editor;
    ngAfterViewInit() {
        tinymce.init({
            selector: '#' + this.elementId,
            plugins: [ 'paste', 'table'],
            skin_url: 'assets/skins/lightgray',
            height: 250,
            branding: false,
            toolbar: [
                " bold italic underline | link image | alignleft aligncenter alignright | indent outdent"
            ],
            menubar: false,
            setup: editor => {
                this.editor = editor;
            },
        });  
    }

    ngOnDestroy() {
        tinymce.remove(this.editor);
    }

    getVisibilityClass()
    {
        return this.controlVisible ? "controlVisible" : "controlInvisible";
    }
 
}
