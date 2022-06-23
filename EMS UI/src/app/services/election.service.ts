import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apis } from '../constants/app.constants';


@Injectable({
  providedIn: 'root'
})
export class ElectionService {

  baseUrl:string;
  constituency:string;
  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getElections() {
    return this.http.get( this.baseUrl+Apis.getElections,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }  

  getCurrentElections() {
    return this.http.get( this.baseUrl+Apis.getCurrentElections,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

  registerElection(electionObject) {
    return this.http.post( this.baseUrl+Apis.registerElection, electionObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }
  registerVote(electionObject) {
    return this.http.post( this.baseUrl+Apis.registerVote, electionObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

}

  
 