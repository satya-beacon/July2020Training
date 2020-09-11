import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

//import employee module 
import { EmployeeModule } from './employee/employee.module';
import { HomeComponent } from './home/home.component';


//import the app routing module 
import { AppRoutingModule } from './app-routing.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent,    
  ],
  imports: [
    BrowserModule,
    EmployeeModule,
    AppRoutingModule
       
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
