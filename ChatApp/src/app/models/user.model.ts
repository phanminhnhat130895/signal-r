import { Messenger } from './message.model';


export class User{
    public UserId: string;
    public UserName: string;
    public ConnectionId: string;
    public IsHaveNewMessage: boolean = false;
    public Message: Messenger[] = [];
}