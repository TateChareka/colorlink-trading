import { Component } from '@angular/core';
import * as appGlobals from'./app-globals';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  
  getActivePageTitle()
  { 
    return appGlobals.ActivePageTitle; 
  }

  isSignedIn()
  {
    return appGlobals.UserIsSignedIn;
  }

}
