import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apis } from '../constants/app.constants';

@Injectable({
  providedIn: 'root'
})
export class PartyService {

  baseUrl:string;
  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getPartys() {
    return this.http.get( this.baseUrl+Apis.getPartys,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

  addParty(partyObject) {
    return this.http.post( this.baseUrl+Apis.registerParty, partyObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }
}
