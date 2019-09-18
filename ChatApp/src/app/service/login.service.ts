import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { baseUrl } from '../common/const';

@Injectable()
export class LoginService{
    constructor(private httpClient : HttpClient){}

    getLogin(data: string) : Observable<string>{
        let url = baseUrl + "login/get-login";
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
        return this.httpClient.post<string>(url, data, {headers: header});
    }
}