import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'; //built-in service for http calls to api
import { GitUserModel } from './models/git-user.model';

@Injectable({
    providedIn: 'root'
})
export class GithubService {

    private readonly baseURL = 'https://api.github.com';

    constructor(private http: HttpClient) {

    }

    public getGitUsers() : Observable<GitUserModel[]> {
        return this.http.get<GitUserModel[]>(`${this.baseURL}/users`);
    }

    public getGitUserByName(name: string) : Observable<GitUserModel> {
        return this.http.get<GitUserModel>(`${this.baseURL}/users/${name}`);
    }
}