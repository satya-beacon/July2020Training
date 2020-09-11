import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from '../../models/login.model';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginModel: UserLoginModel;
  isSubmitted = false;
  invalidCrenential = null;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.loginModel = { username: undefined, password: undefined};
  }

  loginUser(event: any) {
    //validate yoru login
    if(this.isFormValid){
      this.isSubmitted = false;
      const isValid = this.userService.validateLogin(this.loginModel);
      if(isValid){
       let loggedUser = this.userService.getUserByUsername(this.loginModel.username);
       sessionStorage.setItem('userToken', loggedUser.username);
       if(loggedUser.username === 'admin') {
        this.router.navigate(['/admin']);
       }else{
        this.router.navigate(['/welcome']);
       }
      }else {
      this.invalidCrenential = "Invalid Credentails. Please try again";
      }
    }else{
      this.isSubmitted = true;
    }
  
  }

  get isFormValid() {
    if(this.loginModel.username  && this.loginModel.password)
     return true;
    else 
     return false;
  }

}
