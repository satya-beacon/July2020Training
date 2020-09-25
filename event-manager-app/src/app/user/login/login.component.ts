import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UserLoginModel } from '../../models/login.model';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginModel: UserLoginModel;
  isSubmitted = false;
  invalidCrenential = null;

  @ViewChild("loginForm") loginForm: NgForm;

  constructor(private userService: UserService, private router: Router, private authServie: AuthService) { }

  ngOnInit(): void {
    this.loginModel = { username: undefined, password: undefined};
  }

  loginUser(event: any) {
    //validate yoru login
    if(this.isFormValid){
      this.isSubmitted = false;

      let loggedUser;

      this.userService.validateLogin(this.loginModel).subscribe(response => {
       
       loggedUser = response;
       sessionStorage.setItem('userToken', loggedUser.username);
       sessionStorage.setItem('token', loggedUser.token);
      
       //emit the value to subject observable to trigger the event
       this.authServie.login();
       
       if(loggedUser.username === 'admin') {
        this.router.navigate(['/admin']);
       }else{
        this.router.navigate(['/welcome']);
       }

      }, error => {
        this.invalidCrenential = 'User not exists!';
      });

    }else{
      this.isSubmitted = true;
    }
  
  }

  get isFormValid() {
    if(this.loginModel.username  && this.loginModel.password) {
      return true;
    }
    else 
    {
      return false;
    }
  }


  public canDeactivate(): boolean {
    if(this.loginForm.dirty){
      return false;
    }

    return true;
  }
}
