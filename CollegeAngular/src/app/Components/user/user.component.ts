import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/Models/user.model';
import { UserService } from 'src/app/Services/user.service';
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { UsereditComponent } from './useredit/useredit.component';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
  constructor(private userService : UserService
             ,private modalService: BsModalService
             ,private toastr: ToastrService
             ,private route : Router
             ) { }
  users : UserModel[];
  bsModalRef: BsModalRef;
  ngOnInit(): void {
    this.userService.getUsers().subscribe((result) => {      
      this.users = result.data;   
    });   
  }
  addUser() {
    this.bsModalRef = this.modalService.show(UsereditComponent);    
    this.bsModalRef.content.onClose = new Subject ();
    this.bsModalRef.content.onClose.subscribe((result: any) => {     
      if(result.status == "Ok"){
        this.toastr.success('Success', 'User Added succesfully!');
        this.users.push(result.data);
      }
   })
  } 
  onEdit(user : UserModel):void{
    let newCourse= Object.assign({}, user);
    const initialState =  {
     user
    };
    this.bsModalRef = this.modalService.show(UsereditComponent,{ initialState } );            
    this.bsModalRef.content.onClose = new Subject ();
    this.bsModalRef.content.onClose.subscribe((result: any) => {      
      if(result.status == "Ok"){       
        this.toastr.success('Success', 'User Editted succesfully!');
      }
   })
  } 
  onDelete(id : number):void{    
   this.userService.DeleteUser(id).subscribe(
     res => {
      if(res)
      {
        this.userService.getUsers().subscribe(result => {
          this.users = result;   
        });
        this.toastr.success('Success', 'User deletted succesfully!');
      }  
     });   
  } 
}
