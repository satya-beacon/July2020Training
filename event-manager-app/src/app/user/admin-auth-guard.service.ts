import { Injectable } from "@angular/core";
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class AdminAuthGuard implements CanActivate {
    constructor(private router: Router, private auth: AuthService) {

    }

    canActivate(): boolean {
        if(!this.auth.isAdmin()) {
            this.router.navigate(['login']);
            return false;
        }

        return true;
    }
}