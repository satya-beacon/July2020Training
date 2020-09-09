import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

//import employee module 
import { EmployeeModule } from './employee/employee.module';


@NgModule({
  declarations: [
    AppComponent,    
  ],
  imports: [
    BrowserModule,
    EmployeeModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
