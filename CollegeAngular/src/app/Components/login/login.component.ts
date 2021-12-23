import { variable } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';
import { validators } from 'src/environments/environment';
import { HeaderComponent } from '../Shared/header/header.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit { 
  constructor(private loginService : LoginService,private route:Router) { }

  loginForm = new FormGroup({
    name: new FormControl('',Validators.required),
    password: new FormControl('',Validators.pattern(validators.password)),
  });

  ngOnInit(): void {
    sessionStorage.clear();
  }

  onLogin() : void
  {
     this.loginService.Login(this.loginForm.value).subscribe((res)=>
     {
       
        sessionStorage.setItem('user',res.data.user.name);
        sessionStorage.setItem('token',res.data.token);
        this.loginForm.reset();
        this.route.navigate(['']);           
        this.loginService.isLoggedIn.next(true);
     });     
     
  }
}
