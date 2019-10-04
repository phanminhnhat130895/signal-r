import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShareService } from './share.service';
import { baseUrl } from '../common/const';
import { Observable } from 'rxjs';
import { UserMessage } from '../models/user-message.model';

@Injectable()
export class ChatService{
    constructor(private httpClient: HttpClient,
                private shareService: ShareService){}

    private hubConnection: signalR.HubConnection;

    createConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
                                        .withUrl("http://localhost:61285/chat", { accessTokenFactory: () => this.shareService.getAccessToken() })
                                        .build();
    }

    getHubConnection(){
        return this.hubConnection;
    }

    // addTransferDataListener = () => {
    //     this.hubConnection.on("server-send-message", (user, message) => {
    //         console.log("receive: " + user + " " + message);
    //     })

    //     this.hubConnection.on("test-send", (data) => {
    //         console.log("receive: " + data);
    //     })
    // }

    getInitHeader(){
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
        header = header.append('Authorization', 'Bearer ' + this.shareService.getAccessToken());
        return header;
    }

    getMessage(data: string) : Observable<UserMessage[]>{
        let url = baseUrl + "chat/get-message";
        let header = this.getInitHeader();
        return this.httpClient.post<UserMessage[]>(url, data, {headers: header});
    }

    saveMessage(message: UserMessage){
        let url = baseUrl + "chat/save-message";
        let header = this.getInitHeader();
        return this.httpClient.post<UserMessage[]>(url, message, {headers: header});
    }

    mongoGetMessage(data: string) : Observable<UserMessage[]>{
        let url = baseUrl + "chat/mongo-get-message";
        let header = this.getInitHeader();
        return this.httpClient.post<UserMessage[]>(url, data, {headers: header});
    }

    mongoSaveMessage(message: UserMessage){
        let url = baseUrl + "chat/mongo-save-message";
        let header = this.getInitHeader();
        return this.httpClient.post<UserMessage[]>(url, message, {headers: header});
    }
}