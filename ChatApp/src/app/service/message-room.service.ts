import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/app/common/const';
import { ShareService } from './share.service';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { MessageRoom } from '../models/message-room.model';
import { UserMessage } from '../models/user-message.model';

@Injectable()
export class MessageRoomService{
    constructor(private httpClient : HttpClient,
                private shareService: ShareService){}

    getInitHeader(){
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
        header = header.append('Authorization', 'Bearer ' + this.shareService.getAccessToken());
        return header;
    }

    GetListMessage(data: string): Observable<UserMessage[]>{
        let url = baseUrl + "message-room/get-list-message";
        let header = this.getInitHeader();
        return this.httpClient.post<UserMessage[]>(url, data, {headers: header});
    }

    AddMessage(message: MessageRoom){
        let url = baseUrl + "message-room/add-message";
        let header = this.getInitHeader();
        return this.httpClient.post(url, message, {headers: header});
    }
}