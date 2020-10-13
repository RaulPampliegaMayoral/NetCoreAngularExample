import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Shopping } from '../models/shopping';

@Component({
  selector: 'shopping',
  template: `<div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">{{shoppingValue.name}}</h5>
  </div>
  <ul *ngFor="let item of shoppingValue.items">
    <li class="list-group-item">{{item.name}}</li>  
  </ul>
</div>`
})
export class ShoppingComponent {
  @Input() shoppingValue: Shopping;
  //@Output() inputChange = new EventEmitter<Shopping>();
}
