import { Injectable } from '@angular/core';
import { ACCESS_TOKEN } from '../common/const';
import * as jwt_decode from 'jwt-decode';

@Injectable()
export class ShareService{
    constructor(){}

    setAccessToken(data: string){
        sessionStorage.setItem(ACCESS_TOKEN, data);
    }

    getAccessToken(){
        return sessionStorage.getItem(ACCESS_TOKEN);
    }

    clearAccessToken(){
        sessionStorage.removeItem(ACCESS_TOKEN);
    }

    getUserId(){
        let data = sessionStorage.getItem(ACCESS_TOKEN);
        if(data){
            let userLogin = jwt_decode(data);
            return userLogin.UserId;
        }
        return null;
    }
}