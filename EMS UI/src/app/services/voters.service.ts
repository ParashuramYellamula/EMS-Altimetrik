import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Apis } from '../constants/app.constants';

@Injectable({
  providedIn: 'root'
})
export class VotersService {

  baseUrl:string;

  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getVoters() {
    return this.http.get( this.baseUrl+Apis.getVoters,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

  addVoter(voterObject) {
    return this.http.post( this.baseUrl+Apis.registerVoter, voterObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }
}
