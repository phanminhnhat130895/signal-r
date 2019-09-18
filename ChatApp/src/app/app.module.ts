import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatComponent } from './components/chat/chat.component';
import { ChatService } from './service/chat.service';
import { LoginService } from './service/login.service';
import { LoginComponent } from './components/login/login.component';
import { ShareService } from './service/share.service';
import { AuthGuard } from './guard/auth.guard';
import { RoomService } from './service/room.service';
import { MessageRoomService } from './service/message-room.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ShareService,
    ChatService, 
    LoginService,
    AuthGuard,
    RoomService,
    MessageRoomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
