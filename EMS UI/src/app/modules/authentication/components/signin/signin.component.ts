import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  winHeight: number;
  loginForm: FormGroup;
  errMessage: string = '';
  constructor(private route: Router, private fb:FormBuilder,private authService:AuthService) { }

  ngOnInit(): void {
    this.winHeight = window.innerHeight;
    this.initialiseForm();
  }

  initialiseForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  signIn(loginForm:FormGroup) {
    //(loginForm.value);
    let loginObject = {};
    loginObject['name'] = loginForm.value.username;
    loginObject['password'] = loginForm.value.password;
    this.authService.signIn(loginObject).subscribe(res => {
      const data:any = res;
      localStorage.setItem("token",data.token);

      if(loginForm.value.username == 'admin') {
        this.route.navigate(['/admin']);
      } else {
        this.route.navigate(['/voters']);
      }
    },err => {
      console.log("Err",err);
    });
  }

  signUp() {
    this.route.navigate(['/signup']);
  }

}
