import { Injectable } from '@angular/core';
import { UserLoginModel } from '../models/login.model';
import { UserModel } from '../models/user.model';
import { USERDATA } from './mock/user-mock.data';
import { Observable, of } from 'rxjs';
import { ConfigService } from '../shared/config.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    
    private readonly baseURL = 'https://localhost:44342/api/eCommerceWeb';

    private data: UserModel [];

    constructor(private congService: ConfigService, private httpClient: HttpClient) {
        if( localStorage.getItem('users') !== null && localStorage.getItem('users') !== undefined ) {
            this.data = JSON.parse(localStorage.getItem('users'));
        }else {
            this.data = USERDATA;
            localStorage.setItem('users', JSON.stringify(this.data));
        }
    }


    public getUsers(): Observable<UserModel []> {
        if( this.congService.configSettings.debugMode === 'Test' ) {
            return of(this.data);
        }else {
            return of(null);
        }
    }


    public validateLogin(userLoginModel: UserLoginModel): Observable<UserModel> {
        // var result = this.data.filter(u => u.username === userLoginModel.username && u.password === userLoginModel.password);
        // if(result != null && result.length === 1){
        //    return of(true);
        // }

        // return of(false);
        return this.httpClient.post<UserModel>(`${this.baseURL}/authenticate`, JSON.stringify(userLoginModel) );
    }


    public getUserByUsername(username: string): Observable<UserModel> {
        // let userModel = null;
        // let result = this.data.filter(u => u.username === username);
        // if(result != null && result.length === 1){
        //     userModel = result[0];
        // }
        // return of(userModel);


        return this.httpClient.get<UserModel>(`${this.baseURL}/users/${username}`);
    }


    public addUser(userModel: UserModel): Observable<any> {
        // userModel.id = this.data.length +1;
        // this.data.push(userModel);
        // localStorage.setItem('users', JSON.stringify(this.data));
        // return of(userModel.id);
        return this.httpClient.post<any>(`${this.baseURL}/users`, JSON.stringify(userModel));
    }
}
