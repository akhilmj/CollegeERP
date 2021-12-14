import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef,ModalOptions } from 'ngx-bootstrap/modal';
import { User } from 'src/app/Models/user';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-useredit',
  templateUrl: './useredit.component.html',
  styleUrls: ['./useredit.component.css']
})
export class UsereditComponent implements OnInit {
  user : User;
  title:string;    
  isEdit : boolean = false;
  constructor(public modalRef: BsModalRef,private userService : UserService,public options: ModalOptions) { }

  ngOnInit(): void {
    this.modalRef.setClass('modal-dialog-centered');
    this.title = "User Registration";
    debugger;
    if(this.user){      
      this.isEdit = true;
    }else{
      this.user = new User();
    }
    
  }
  
  Save():void{  
    debugger;
    if(this.isEdit){
      this.userService.updateUser(this.user).subscribe(result => {
        debugger;
        this.modalRef.content.onClose.next({data:<User>result,status: "Ok", isEdit : this.isEdit, message:"Saved Succesfully"});
        this.modalRef.hide();
      });
    }
    else{
      this.userService.saveUser(this.user).subscribe(result => {
        this.modalRef.content.onClose.next({data:<User>result,status: "Ok", isEdit : this.isEdit, message:"Saved Succesfully"});
        this.modalRef.hide();
      }); 
    }
  }  

  Cancel():void{
    this.modalRef.content.onClose.next({data:"",status: "Errror", message:"error"});
    this.modalRef.hide();
  }
}
