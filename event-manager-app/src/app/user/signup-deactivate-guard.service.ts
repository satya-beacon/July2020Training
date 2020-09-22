import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot } from '@angular/router';
import { SignupComponent } from './signup/signup.component';

@Injectable({
    providedIn: 'root'
})
export class SignupCanDeactivateGuard implements CanDeactivate<SignupComponent> {
    canDeactivate(signupComponent: SignupComponent, route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return signupComponent.isDirtyComponent() || confirm("Hello, There are unsaved changes on the page. You want to continue?");
    }
}