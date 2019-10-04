import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/app/common/const';
import { ShareService } from './share.service';
import { Room } from '../models/room.model';

@Injectable()
export class RoomService{
    constructor(private httpClient : HttpClient,
                private shareService: ShareService){}

    getInitHeader(){
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
        header = header.append('Authorization', 'Bearer ' + this.shareService.getAccessToken());
        return header;
    }

    OnJoinRoom(connectionId: string) : Observable<Room[]>{
        let url = baseUrl + "room/join-room/" + connectionId;
        let header = this.getInitHeader();
        return this.httpClient.get<Room[]>(url, {headers: header});
    }

    MongoJoinRoom(connectionId: string) : Observable<Room[]>{
        let url = baseUrl + "room/mongo-join-room/" + connectionId;
        let header = this.getInitHeader();
        return this.httpClient.get<Room[]>(url, {headers: header});
    }
}