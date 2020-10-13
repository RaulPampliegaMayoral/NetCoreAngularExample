import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Shopping } from '../models/shopping';

import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ShoppingService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Shopping[]>(`${environment.apiUrl}/shopping`);
  }
}
