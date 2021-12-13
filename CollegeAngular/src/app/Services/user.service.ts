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
        return this.http.get<User[]>(`${environment.baseURL}User`);  
  }
}

 
  
 
  
