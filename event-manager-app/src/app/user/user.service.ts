import { Injectable } from '@angular/core';
import { UserLoginModel } from '../models/login.model';
import { UserModel } from '../models/user.model';
import { USERDATA } from './mock/user-mock.data';
import { Observable, of } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private data : UserModel [];

    constructor() {
        if(localStorage.getItem('users') != null && localStorage.getItem('users') != undefined ) {
            this.data = JSON.parse(localStorage.getItem('users'));
        }else {
            this.data = USERDATA;
            localStorage.setItem('users', JSON.stringify(this.data));
        }
    }


    public getUsers() : Observable<UserModel []> {
        return of(this.data);
    }


    public validateLogin(userLoginModel :UserLoginModel): Observable<boolean> {
        var result = this.data.filter(u => u.username === userLoginModel.username && u.password === userLoginModel.password);
        
        if(result != null && result.length === 1){
           return of(true);
        }

        return of(false);
    }


    public getUserByUsername(username : string): Observable<UserModel> {
        let userModel = null;
        let result = this.data.filter(u => u.username === username);
        if(result != null && result.length === 1){
            userModel = result[0];
        }
        return of(userModel);
    }


    public addUser(userModel: UserModel) : Observable<number> {
        userModel.id = this.data.length +1;
        this.data.push(userModel);
        localStorage.setItem('users', JSON.stringify(this.data));
        return of(userModel.id);
    }
}