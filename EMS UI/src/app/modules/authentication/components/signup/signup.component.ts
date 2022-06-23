import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  winHeight: number;
  signUpForm: FormGroup;
  errMessage: string = '';
  constructor(private route: Router, private fb:FormBuilder,private authService:AuthService) { }

  ngOnInit(): void {
    this.winHeight = window.innerHeight;
    this.initialiseForm();
  }

  initialiseForm() {
    this.signUpForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  signUp(signUpForm:FormGroup) {
    //console.log(signUpForm.value);
    let signUpObject = {};
    signUpObject['name'] = signUpForm.value.username;
    signUpObject['password'] = signUpForm.value.password;
    this.authService.signUp(signUpObject).subscribe(res => {
      this.route.navigate(['/signIn']);
    },err => {
      console.log("Err",err);
    });
  }

}
