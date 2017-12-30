import { Component, ViewChild } from '@angular/core';
import { Nav, Platform } from 'ionic-angular';
import { AppConfig } from "./app.config";
import { HomePage } from '../pages/home/home';


@Component({
  templateUrl: 'app.html'
})
export class SchoolDaysApp {
  @ViewChild(Nav) nav: Nav;

  rootPage: any = 'HomePage';
  pages: Array<{ title: string, component: any }>;

  constructor() {
    this.pages = AppConfig.PAGES;
  }

  openPage(page) {
    this.nav.setRoot(page.component);
  }
}
