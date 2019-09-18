import { Component, OnInit, ViewChild } from '@angular/core';
import { ChatService } from '../../service/chat.service';
import { Messenger } from '../../models/message.model';
import { User } from '../../models/user.model';
import { ShareService } from 'src/app/service/share.service';
import { UserMessage } from 'src/app/models/user-message.model';
import { RoomService } from 'src/app/service/room.service';
import { Room } from 'src/app/models/room.model';
import { MessageRoomService } from 'src/app/service/message-room.service';
import { MessageRoom } from 'src/app/models/message-room.model';

declare var $ : any;

@Component({
    selector: 'chat',
    templateUrl: 'chat.component.html'
})

export class ChatComponent implements OnInit {
    constructor(private chatService: ChatService,
                private shareService: ShareService,
                private roomService: RoomService,
                private messageRoomService: MessageRoomService){}

    connection: any = null;

    message: Messenger = new Messenger();
    listUser: User[] = [];
    listRoom: Room[] = [];
    userId: string = "";

    userMessage: UserMessage[] = [];
    oneMessage: UserMessage = new UserMessage();

    selectedUser: User = null;
    selectedRoom: Room = null;

    limit: number = 20;
    offset: number = 0;

    isGetNewMessage: boolean = true;

    chatName: string = "";

    @ViewChild('chat') chatEl;
    @ViewChild('message_data') messageInput;

    ngOnInit(){
        this.onConnect();
    }

    onConnect(){
        this.userId = this.shareService.getUserId();
        this.message.UserId = this.userId;
        this.chatService.createConnection();
        //this.chatService.addTransferDataListener();
        this.connection = this.chatService.getHubConnection();

        this.connection.on("SendListUser", (listUser) => {
            this.listUser = listUser;
            let user = this.listUser.filter(u => u.UserId == this.userId)[0];
            this.roomService.OnJoinRoom(user.ConnectionId)
                .subscribe(res => {
                    if(res && res.length > 0){
                        this.listRoom = res;
                    }
                },
                err => {
                    console.log(err);
                })
        })

        this.connection.on("SendUserConnect", (user) => {
            this.listUser.push(user);
        })

        this.connection.on("SendMessageToOne", (message) => {
            let user = this.listUser.filter(u => u.UserId == message.iduser_send)[0];
            if(this.selectedUser && (this.selectedUser as User).UserId == message.iduser_send){
                this.userMessage.push(message);
                setTimeout(() => {
                    this.chatEl.nativeElement.scrollTop = this.chatEl.nativeElement.scrollHeight;
                }, 10)
            }
            else{
                user.IsHaveNewMessage = true;
            }
        })

        this.connection.on("SendMessageToSelf", (message) => {
            this.userMessage.push(message);
            setTimeout(() => {
                this.chatEl.nativeElement.scrollTop = this.chatEl.nativeElement.scrollHeight;
            }, 10)
        })

        this.connection.on("SendMessageToGroup", (idGroup, message) => {
            this.userMessage.push(message);
            let room = this.listRoom.filter(u => u.idroom == idGroup)[0];
            if(this.selectedUser && this.selectedRoom.idroom == idGroup){
                setTimeout(() => {
                    this.chatEl.nativeElement.scrollTop = this.chatEl.nativeElement.scrollHeight;
                }, 10)
            }
            else{
                room.IsHaveNewMessage = true;
            }
        })

        this.connection.start()
            .then(() => {
                console.log("Connection started.");
                this.connection.invoke("SendListUser");
                this.connection.invoke("SendUserConnect", this.userId);
            },
            err => {
                console.log("Error while starting connection: " + err);
            })
    }

    onSendMessage(){
        if(this.oneMessage.message.trim()){
            if(this.selectedUser){
                this.connection.invoke("SendMessageToOne", this.selectedUser.ConnectionId, this.oneMessage);
                this.chatService.saveMessage(this.oneMessage)
                    .subscribe(res => {
                        
                    },
                    err => {
                        console.log(err);
                    })
            }
            else{
                this.connection.invoke("SendMessageToGroup", this.selectedRoom.idroom, this.oneMessage);
                let data = new MessageRoom();
                data.idroom = this.selectedRoom.idroom;
                data.iduser_send = this.userId;
                data.message = this.oneMessage.message;
                this.messageRoomService.AddMessage(data)
                    .subscribe(res => {

                    },
                    err => {
                        console.log(err);
                    })
            }
            this.oneMessage.message = "";
            this.messageInput.nativeElement.focus();
        }
    }

    onMessageKeyPress(event: any){
        if(event.keyCode === 13){
            this.onSendMessage();
        }
    }

    onSelectUser(user: User){
        if(this.selectedUser != user){
            this.selectedRoom = null;
            this.selectedUser = user;
            this.chatName = this.selectedUser.UserName;
            this.selectedUser.IsHaveNewMessage = false;
            this.oneMessage.iduser_send = this.userId;
            this.oneMessage.iduser_receive = this.selectedUser.UserId;
            this.onGetMessage();
        }
    }

    onGetMessage(){
        this.userMessage = [];
        this.offset = 0;
        let data = JSON.stringify({ iduser_send: this.userId, iduser_receive: (this.selectedUser as User).UserId, limit_mess: this.limit, offset_mess: this.offset });
        this.chatService.getMessage(data)
            .subscribe(res => {
                if(res && res.length > 0){
                    this.userMessage = res;
                    setTimeout(() => {
                        let el = document.getElementsByClassName("chat-frame")[0];
                        el.scrollTop = el.scrollHeight + 50;
                    }, 0);
                }
            },
            err => {
                console.log(err);
            })
    }

    onMouseOver(){
        $(".chat-frame").mouseover(function(){
            $(this).attr("style", "overflow-y: auto");
        })
    }

    onScroll(){
        let that = this;
        $(".chat-frame").scroll(function(){
            let scroll = $(this).scrollTop();
            let height = $(this)[0].scrollHeight;
            if(scroll <= 200){
                if(that.isGetNewMessage){
                    that.isGetNewMessage = false;
                    that.offset = that.offset + 1;
                    if(that.selectedUser){
                        let data = JSON.stringify({ iduser_send: that.userId, iduser_receive: (that.selectedUser as User).UserId, limit_mess: that.limit, offset_mess: that.offset });
                        that.chatService.getMessage(data)
                            .subscribe(res => {
                                if(res && res.length > 0){
                                    that.userMessage = [...res,...that.userMessage];
                                    that.isGetNewMessage = true;
                                    setTimeout(() => {
                                        let el = document.getElementsByClassName("chat-frame")[0];
                                        el.scrollTop = height - 200;
                                    }, 100);
                                }
                            },
                            err => {
                                console.log(err);
                            })
                    }
                    else{
                        let data = JSON.stringify({ idRoom: this.selectedRoom.idroom, limit_mess: that.limit, offset_mess: that.offset });
                        that.messageRoomService.GetListMessage(data)
                            .subscribe(res => {
                                if(res && res.length > 0){
                                    that.userMessage = [...res,...that.userMessage];
                                    that.isGetNewMessage = true;
                                    setTimeout(() => {
                                        let el = document.getElementsByClassName("chat-frame")[0];
                                        el.scrollTop = height - 200;
                                    }, 100);
                                }
                            },
                            err => {
                                console.log(err);
                            })
                    }
                }
            }
            else{
                
            }
        })
    }

    onMouseOut(){
        $(".chat-frame").mouseout(function(){
            $(this).attr("style", "overflow-y: hidden");
        })
    }

    onSelectRoom(room: Room){
        if(this.selectedRoom != room){
            this.selectedUser = null;
            this.selectedRoom = room;
            this.chatName = this.selectedRoom.display_name;
            this.oneMessage.iduser_send = this.userId;
            this.onGetRoomMessage();
        }
    }

    onGetRoomMessage(){
        this.userMessage = [];
        this.offset = 0;
        let data = JSON.stringify({ idRoom: this.selectedRoom.idroom, limit_mess: this.limit, offset_mess: this.offset });
        this.messageRoomService.GetListMessage(data)
            .subscribe(res => {
                if(res && res.length > 0){
                    this.userMessage = res;
                    setTimeout(() => {
                        let el = document.getElementsByClassName("chat-frame")[0];
                        el.scrollTop = el.scrollHeight + 50;
                    }, 0);
                }
            },
            err => {
                console.log(err);
            })
    }

    onCloseChatFrame(){
        this.selectedUser = null;
        this.selectedRoom = null;
    }
}