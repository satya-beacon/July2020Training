import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { interval , Subscription} from 'rxjs';
import { AuthService } from '../../user/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {
  isAuthenticated = false;
  isAdmin = false;
  timespan: string;

  timer = interval(1000); //create an observable

  timerSubscription: Subscription;
  userLoginSubscription: Subscription;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
   
    this.loadNavs(this.authService.isAuthenticated());

    this.userLoginSubscription = this.authService.isUserLogged.subscribe((val) => {
      this.loadNavs(val);
    });



    this.timerSubscription = this.timer.subscribe(() => {
      this.timespan = new Date().toLocaleTimeString();
    });
  }

  private loadNavs(val : boolean) {
    this.isAuthenticated = val;
    this.isAdmin = this.authService.isAdmin();
  }
  logout(event: any) {
    this.authService.signout();
    this.router.navigate(['login']);
  }

  ngOnDestroy() {
    if(this.timerSubscription){
      this.timerSubscription.unsubscribe();
    }

    if(this.userLoginSubscription){
      this.userLoginSubscription.unsubscribe();
    }
  }

}
