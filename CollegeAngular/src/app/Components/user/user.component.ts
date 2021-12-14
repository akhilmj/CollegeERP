import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user';
import { UserService } from 'src/app/Services/user.service';
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { UsereditComponent } from './useredit/useredit.component';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
  constructor(private userService : UserService,private modalService: BsModalService) { }
  users : User[];
  bsModalRef: BsModalRef;
  ngOnInit(): void {
    this.userService.getUsers().subscribe(result => {
      this.users = result;   
    });
  }
  addUser() {
    this.bsModalRef = this.modalService.show(UsereditComponent);    
    this.bsModalRef.content.onClose = new Subject ();
    this.bsModalRef.content.onClose.subscribe((result: any) => {
      console.log('results', result);
      if(result.status == "Ok"){
        this.users.push(result.data);
      }
   })
  } 
  onEdit(user : User):void{
    const initialState =  {
     user
    };
    this.bsModalRef = this.modalService.show(UsereditComponent,{ initialState } );            
    this.bsModalRef.content.onClose = new Subject ();
    this.bsModalRef.content.onClose.subscribe((result: any) => {      
      if(result.status == "Ok" && result.isEdit == false){
        this.users.push(result.data);
      }
   })
  } 
  onDelete(id : number):void{    
    this.userService.DeleteUser(id);
  } 
}
