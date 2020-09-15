import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { UserService } from './user.service';
import { Subject, of, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    
    public isUserLogged = new Subject<boolean>();

    constructor(private userService: UserService) {

    }
    
    public isAdmin() : boolean {
        if(sessionStorage.getItem('userToken') !== null && sessionStorage.getItem('userToken') !== undefined && sessionStorage.getItem('userToken') === 'admin'){
            return true;
        }
        else{
            return false;
        }
    }

    public getLoggedUser() : Observable<UserModel> {
        if(sessionStorage.getItem('userToken') !== null && sessionStorage.getItem('userToken') !== undefined){
            return this.userService.getUserByUsername(sessionStorage.getItem('userToken'));
        }
        else{
            return of(null);
        }
    }
    
    public login() {
        this.isUserLogged.next(true);
    }

    public signout(){
        sessionStorage.clear();
        this.isUserLogged.next(false);
    }
}