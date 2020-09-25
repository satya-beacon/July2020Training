import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConfigService } from './shared/config.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  configSubscription: Subscription;
  constructor(private configService: ConfigService) {

  }


  ngOnInit() {
    this.configSubscription =  this.configService.load().subscribe(response => {
      this.configService.configSettings = response;
    }, error => {

    });
  }

  ngOnDestroy() {
    if(this.configSubscription){
      this.configSubscription.unsubscribe();
    }
  }
}
