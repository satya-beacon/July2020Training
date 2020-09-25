import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from '../user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  isSubmitted = false;

  options = [{label: 'Male', value: 'Male'}, {label: 'Female', value: 'Female'}];

  constructor(private fb: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit(): void {

    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: [''],
      email: ['', Validators.required],
      mobile: ['', Validators.required],
      gender: ['']
    });

  }


  onSubmit(event: any) {
    // write logic to save
    if(this.signupForm.valid) {
      this.isSubmitted = false;
     
      const userModel: UserModel = {
        username: this.signupForm.get('username').value,
        password: this.signupForm.get('password').value,
        firstName: this.signupForm.get('firstName').value,
        lastName: this.signupForm.get('lastName').value,
        email: this.signupForm.get('email').value,
        mobile: this.signupForm.get('mobile').value,
        gender: this.signupForm.get('gender').value,
      };

      this.userService.addUser(userModel).subscribe(val => {
        this.router.navigate(['login']);
      }, 
      error => {
        console.log('Error in creating user account' + JSON.stringify(error));
      });

    }else {
      this.isSubmitted = true;
    }
  }

  public isDirtyComponent(): boolean {
    if(this.signupForm.dirty){
      return false;
    }

    return true;
  }
}
