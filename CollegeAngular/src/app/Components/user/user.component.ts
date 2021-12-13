import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService : UserService) { }
  users : User[]
  ngOnInit(): void {
    this.userService.getUsers().subscribe(result => {
      this.users = result;   
    });
  }
  
}
