import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apis } from '../constants/app.constants';


@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  baseUrl:string;
  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  getCandidates() {
    return this.http.get( this.baseUrl+Apis.getCandidates,{
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

  registerCandidate(candidateObject) {
    return this.http.post( this.baseUrl+Apis.registerCandidate, candidateObject, {
      headers: {
        Authorization: 'Bearer '+localStorage.getItem('token')
      }
    });
  }

}

  
 