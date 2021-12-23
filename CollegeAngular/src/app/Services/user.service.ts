import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { UserModel } from '../Models/user.model';       

@Injectable({
  providedIn: 'root'
})
export class UserService { 
  users: UserModel[];
  isdeleted: boolean;
  headers = new HttpHeaders().append('Authorization',  `Bearer ${sessionStorage.getItem('token')}`);
  constructor(private http : HttpClient) { 

  }
  
  getUsers():  Observable<any>{    
    return this.http.get<any>(`User`);  
  }
  saveUser(user:UserModel):Observable<any>{
    return this.http.post<any>(`User`,user);
  }
  DeleteUser(id:number):Observable<any>{    
    return this.http.delete<any>(`User/`+id);    
  }
  updateUser(user:UserModel):Observable<any>{
    const id  = user.id;
    return this.http.put<any>(`User/`+ id, user);
  }
  
}

 
  
 
  
