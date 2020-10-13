import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { SignalRNotificationService, ShoppingService } from '../services';
import { Shopping } from '../models/shopping';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user: User;
  shoppings: Shopping[] = [];

  constructor(private accountService: AccountService,
              private shoppingService: ShoppingService,
              private signalRNotification: SignalRNotificationService) {
    this.user = this.accountService.userValue;
  }

  ngOnInit(): void {
    //Register to websocket connection
    this.signalRNotification.initialize();
    this.signalRNotification.Notification.subscribe(data => {
      this.shoppings.push(data);
    });

    this.shoppingService.getAll().subscribe(shoppings => this.shoppings = shoppings);
  }
}
