import { Component, OnInit, OnDestroy } from '@angular/core';

//import your service
import { GithubService } from '../git-hub.service';


import { Subscription  } from 'rxjs';
import { GitUserModel } from '../models/git-user.model';

@Component({
  selector: 'app-git-users',
  templateUrl: './git-users.component.html',
  styleUrls: ['./git-users.component.css']
})
export class GitUsersComponent implements OnInit, OnDestroy {

  gitSubscription: Subscription;
  gitUsers: GitUserModel[];

  constructor(private gitHubService: GithubService) { }

  ngOnInit(): void {
   this.gitSubscription = this.gitHubService.getGitUsers().subscribe(response => {
     this.gitUsers = response;
     console.table(this.gitUsers);
    },
    error => {
      console.log('Error is accessing git users');
    }
    );
  }


  ngOnDestroy() {
    this.gitSubscription.unsubscribe();
  }

}
