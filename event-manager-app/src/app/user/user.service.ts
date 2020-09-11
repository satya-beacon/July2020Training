import { Injectable } from '@angular/core';
import { UserLoginModel } from '../models/login.model';
import { UserModel } from '../models/user.model';
import { USERDATA } from './mock/user-mock.data';

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


    public getUsers() : UserModel [] {
        return this.data;
    }


    public validateLogin(userLoginModel :UserLoginModel): boolean {
        var result = this.data.filter(u => u.username === userLoginModel.username && u.password === userLoginModel.password);
        
        if(result != null && result.length === 1){
           return true;
        }

        return false;
    }


    public getUserByUsername(username : string): UserModel {
        let userModel = null;
        let result = this.data.filter(u => u.username === username);
        if(result != null && result.length === 1){
            userModel = result[0];
        }
        return userModel;
    }
}