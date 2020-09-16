import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { GithubService } from '../git-hub.service';
import { GitUserModel } from '../models/git-user.model';

@Component({
  selector: 'app-git-user-details',
  templateUrl: './git-user-details.component.html',
  styleUrls: ['./git-user-details.component.css']
})
export class GitUserDetailsComponent implements OnInit, OnDestroy {

  gitUserModel: GitUserModel;
  gitUserSubscription: Subscription;

  constructor(private gitHubService: GithubService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const name = params.get('name');
      this.gitUserSubscription =  this.gitHubService.getGitUserByName(name).subscribe(response => {
        this.gitUserModel = response;
        console.table(this.gitUserModel);
      }, error => {
        console.log("Error in accessing git user");
      });
    });
  }

  ngOnDestroy() {
    this.gitUserSubscription.unsubscribe();
  }

}
