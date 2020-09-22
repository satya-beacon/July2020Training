import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot } from '@angular/router';
import { LoginComponent } from './login/login.component';

@Injectable({
    providedIn: 'root'
})
export class LoginCanDeactivateGuard implements CanDeactivate<LoginComponent> {
    canDeactivate(loginComponent: LoginComponent, route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return loginComponent.canDeactivate() || confirm("Hello, There are unsaved changes on the page. You want to continue?");
    }
}