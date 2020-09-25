import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class MockAuthService {
    public isAuthenticated(): boolean {
        if(sessionStorage.getItem('token')){
            return true;
        }else {
            return false;
        }
    }
}