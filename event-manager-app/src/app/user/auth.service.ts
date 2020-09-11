import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { UserService } from './user.service';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private userService: UserService) {

    }
    public isAuthenticated() : boolean {
        if(sessionStorage.getItem('userToken') !== null && sessionStorage.getItem('userToken') !== undefined){
            return true;
        }
        else{
            return false;
        }
    }

    public isAdmin() : boolean {
        if(sessionStorage.getItem('userToken') !== null && sessionStorage.getItem('userToken') !== undefined && sessionStorage.getItem('userToken') === 'admin'){
            return true;
        }
        else{
            return false;
        }
    }

    public getLoggedUser() : UserModel {
        if(sessionStorage.getItem('userToken') !== null && sessionStorage.getItem('userToken') !== undefined){
            return this.userService.getUserByUsername(sessionStorage.getItem('userToken'));
        }
        else{
            return null;
        }
    }
    public signout(){
        sessionStorage.clear();
    }
}