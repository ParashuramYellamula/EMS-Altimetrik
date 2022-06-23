import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apis } from '../constants/app.constants';

@Injectable({
  providedIn: 'root'
})
export class ConstituencyService {

  baseUrl:string;
  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getConstituencys() {
    return this.http.get( this.baseUrl+Apis.getConstituencys,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

  addConstituency(constituencyObject) {
    return this.http.post( this.baseUrl+Apis.addConstituency, constituencyObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }
  removeConstituency(constituencyObject) {
    return this.http.post( this.baseUrl+Apis.removeConstituency, constituencyObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }
}
 