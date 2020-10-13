import { Injectable, EventEmitter } from '@angular/core';
//import { AuthService } from '../auth/auth.service';

import { environment } from '../../environments/environment';
import { HubConnection } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';

@Injectable()
export class SignalRNotificationService {

    private hubConnection: HubConnection | undefined;
    public Notification: EventEmitter<string> = new EventEmitter<string>();

    constructor(/*private authService: AuthService*/) {
    }

    public initialize(): void {
        this.stopConnection();

      this.hubConnection = new signalR.HubConnectionBuilder().withUrl(`${environment.apiUrl}/ws`, {
            //accessTokenFactory: () => {
            //    return this.authService.getToken();
          //}
          //skipNegotiation: true,
          //transport: signalR.HttpTransportType.WebSockets
        }).configureLogging(signalR.LogLevel.Information).build();

      this.hubConnection.on("ReceiveMessage", (data: any) => {
            this.Notification.emit(data);
        });

        this.hubConnection.start().then((data: any) => {
            console.log('Now connected');
        }).catch((error: any) => {
            console.log('Could not connect ' + error);
            setTimeout(() => this.initialize(), 3000);
        });
    }

    stopConnection() {
        if (this.hubConnection) {
            this.hubConnection.stop();
            this.hubConnection = null;
        }
    };
}
