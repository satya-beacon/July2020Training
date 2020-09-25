import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAuthGuard } from './admin-auth-guard.service';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './auth-guard.service';
import { LoginComponent } from './login/login.component';
import { SignupCanDeactivateGuard } from './signup-deactivate-guard.service';
import { LoginCanDeactivateGuard } from './login-deactivate-guard.service';

import { SignupComponent } from './signup/signup.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LoggedUserResolverService } from './logged-user-resolver.service';

const routes: Routes = [
 { path: 'login', component: LoginComponent, canDeactivate: [LoginCanDeactivateGuard]},
 { path: 'signup', component: SignupComponent, canDeactivate: [SignupCanDeactivateGuard] },
 { path: 'welcome', component: WelcomeComponent, canActivate: [AuthGuard], resolve: { loggedUser: LoggedUserResolverService }},
 { path: 'admin', component: AdminComponent, canActivate: [AdminAuthGuard]}
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class UserRoutingModule {
    
}
