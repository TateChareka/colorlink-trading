import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { LegalPage } from './legal';
import { DirectivesModule } from "../../directives/directives.module";


@NgModule({
  declarations: [
    LegalPage,
  ],
  imports: [
    IonicPageModule.forChild(LegalPage),
    DirectivesModule
  ],
})
export class LegalPageModule {}
