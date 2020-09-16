import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppSettings } from '../models/appSettings.model';

@Injectable({
    providedIn: 'root'
})
export class ConfigService {
    private readonly assets = 'assets/config/config.json';
    public configSettings: AppSettings;

    constructor(private http: HttpClient) {

    }

    load(): Observable<AppSettings> {
       return this.http.get<AppSettings>(this.assets);
    }
}