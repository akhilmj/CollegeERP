import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginModel } from '../Models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService { 
  public isLoggedIn = new BehaviorSubject(false);
  constructor(private http:HttpClient) { 
    
  }
   
  Login(form : LoginModel):Observable<any>{
    return this.http.post('Login',form);   
  }
  
}
