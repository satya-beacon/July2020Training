import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GitUserDetailsComponent } from './git-user-details/git-user-details.component';
import { GitUsersComponent } from './git-users/git-users.component';

const routes: Routes = [
{path: 'git', component: GitUsersComponent},
{path: 'git/:name', component: GitUserDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GitHubRoutingModule {

}