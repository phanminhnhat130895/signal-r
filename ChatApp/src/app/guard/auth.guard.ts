import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ShareService } from '../service/share.service';

@Injectable()
export class AuthGuard implements CanActivate{
    constructor(private router: Router,
                private shareService: ShareService){}
            
    canActivate(){
        let userId = this.shareService.getUserId();
        if(userId){
            return true;
        }
        this.router.navigate(['']);
        return false;
    }
}