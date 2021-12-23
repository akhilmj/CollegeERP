import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef,ModalOptions } from 'ngx-bootstrap/modal';
import { UserModel } from 'src/app/Models/user.model';
import { UserService } from 'src/app/Services/user.service';
import { environment, validators } from 'src/environments/environment';

@Component({
  selector: 'app-useredit',
  templateUrl: './useredit.component.html',
  styleUrls: ['./useredit.component.css']
})
export class UsereditComponent implements OnInit {
  user : UserModel;
  title:string;    
  isEdit : boolean = false;
  public emailPattern : string = validators.email; 
  public phonePattern : string = validators.phone; 
  public passwordPattern : string = validators.password; 
  constructor(public modalRef: BsModalRef,private userService : UserService,public options: ModalOptions) { }

  ngOnInit(): void {
    this.modalRef.setClass('modal-dialog-centered');
    this.title = "User Registration";    
    if(this.user){      
      this.isEdit = true;
    }else{
      this.user = new UserModel();
    }    
  }
  Cancel():void{
    this.modalRef.content.onClose.next({data:"",status: "Errror", message:"error"});
    this.modalRef.hide();
  }
  onSubmit(form: any){    
    if(this.isEdit){
      this.userService.updateUser(<UserModel>form.value).subscribe(result => {        
        this.modalRef.content.onClose.next({data:<UserModel>result,status: "Ok",  message:"Saved Succesfully"});
        this.modalRef.hide();
      });
    }
    else{
      this.userService.saveUser(<UserModel>form.value).subscribe(result => {
        this.modalRef.content.onClose.next({data:<UserModel>result,status: "Ok", message:"Saved Succesfully"});
        this.modalRef.hide();
      }); 
    }
  }
}
