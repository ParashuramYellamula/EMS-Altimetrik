import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apis } from '../constants/app.constants';

@Injectable({
  providedIn: 'root'
})
export class SymbolService {

  baseUrl:string;
  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getSymbols() {
    return this.http.get( this.baseUrl+Apis.getSymbols,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

}

