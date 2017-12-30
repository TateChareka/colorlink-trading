import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicStorageModule } from '@ionic/storage';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { AppConfig } from "./app.config";
import { SchoolDaysApp } from './app.component';
import { DirectivesModule } from "../directives/directives.module";


@NgModule({
  declarations: [
    SchoolDaysApp
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    IonicModule.forRoot(SchoolDaysApp),
    IonicStorageModule.forRoot(AppConfig.STORAGE_CONFIG),
    DirectivesModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    SchoolDaysApp
  ],
  providers: [
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    AppConfig.SERVICES,
    AppConfig.PROVIDERS
  ]
})
export class AppModule { }
