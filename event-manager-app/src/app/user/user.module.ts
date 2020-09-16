import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';

import { UserRoutingModule } from './user-routing.module';

//import FormsModule for Template driven forms
import { FormsModule } from '@angular/forms';

//import module for reactive forms
import { ReactiveFormsModule } from '@angular/forms';

import { WelcomeComponent } from './welcome/welcome.component';
import { AdminComponent } from './admin/admin.component';
import { SignupComponent } from './signup/signup.component';


@NgModule({
  declarations: [LoginComponent, WelcomeComponent, AdminComponent, SignupComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UserRoutingModule
  ]
})
export class UserModule { }
