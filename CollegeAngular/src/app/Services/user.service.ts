import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  users: User[];
  constructor(private http : HttpClient) { 

  }
  getUsers():  Observable<User[]>{    
        return this.http.get<User[]>(`${environment.baseURL}UserContorller`);  
  }
  saveUser(user:User):Observable<User>{
    return this.http.post<User>(`${environment.baseURL}UserContorller`,user);
  }
  DeleteUser(id:number):void{
    this.http.delete(`${environment.baseURL}UserContorller/`+id).subscribe();
  }
  updateUser(user:User):Observable<User>{
    const id  = user.id;
    return this.http.put<User>(`${environment.baseURL}UserContorller/`+id, user);
  }
}

 
  
 
  
