import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from '../../models/login.model';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { typeWithParameters } from '@angular/compiler/src/render3/util';

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
        console.log("Error in authenticating user");
        this.invalidCrenential = "User not exists!";
      });

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
