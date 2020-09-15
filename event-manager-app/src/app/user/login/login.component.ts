import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from '../../models/login.model';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginModel: UserLoginModel;
  isSubmitted = false;
  invalidCrenential = null;

  constructor(private userService: UserService, private router: Router, private authServie: AuthService) { }

  ngOnInit(): void {
    this.loginModel = { username: undefined, password: undefined};
  }

  loginUser(event: any) {
    //validate yoru login
    if(this.isFormValid){
      this.isSubmitted = false;
      let  isValid = false;
     
      this.userService.validateLogin(this.loginModel).subscribe(val => {
        isValid = val;
      });


      if(isValid){
       let loggedUser;
       
       this.userService.getUserByUsername(this.loginModel.username).subscribe(response => {
          loggedUser = response;
        });
        
       sessionStorage.setItem('userToken', loggedUser.username);
      
       //emit the value to subject observable to trigger the event
       this.authServie.login();
       
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
