import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Apis } from '../constants/app.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  baseUrl:string;

  constructor(private http: HttpClient) { 
    if (window.location.hostname === 'localhost') {
      this.baseUrl = Apis.devUrl;
    }
  }

  signIn(loginModel) {
    return this.http.post( this.baseUrl+Apis.signin, loginModel);
  }

  signUp(signUpModel) {
    return this.http.post( this.baseUrl+Apis.signup, signUpModel);
  }
  
}
