import { Injectable } from "@angular/core";
import { UserModel } from '../models/user.model';
import { AuthService } from './auth.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoggedUserResolverService implements Resolve<UserModel> {
    constructor(private auth: AuthService){

    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<UserModel> | UserModel {
        return this.auth.getLoggedUser();
    }
}