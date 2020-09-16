import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GitUsersComponent } from './git-users/git-users.component';
import { GitHubRoutingModule } from './git-hub-routing.module';

import { GitUserDetailsComponent } from './git-user-details/git-user-details.component'; //built-in module for http calls 

@NgModule({
    declarations: [GitUsersComponent, GitUserDetailsComponent],
    imports: [CommonModule, GitHubRoutingModule],
    exports: [], 
    providers: []
})
export class GitHubModule {
    
}