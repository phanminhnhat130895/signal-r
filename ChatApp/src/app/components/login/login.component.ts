import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/service/login.service';
import { ShareService } from 'src/app/service/share.service';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
    constructor(private loginService: LoginService,
                private shareService: ShareService,
                private router: Router){}

    userName: string = "";
    passWord: string = "";

    ngOnInit(){
        if(this.shareService.getUserId()){
            this.router.navigate(['/chat']);
        }
    }

    onLogin(){
        let dataLogin = JSON.stringify({ UserName: this.userName, PassWord: this.passWord });
        // this.loginService.getLogin(dataLogin)
        //     .subscribe(res => {
        //         if(res && res != "Unauthenticated!"){
        //             this.shareService.setAccessToken(res);
        //             this.router.navigate(["/chat"]);
        //         }
        //     },
        //     err => {
        //         console.log(err);
        //     })

        this.loginService.mongoGetLogin(dataLogin)
            .subscribe(res => {
                if(res && res != "Unauthenticated!"){
                    this.shareService.setAccessToken(res);
                    this.router.navigate(["/chat"]);
                }
            },
            err => {
                console.log(err);
            })
    }
}