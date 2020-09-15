import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  loggedUser: UserModel;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
   
     this.authService.getLoggedUser().subscribe(response => {
       this.loggedUser = response;
     });
  }

}
