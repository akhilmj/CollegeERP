import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {  
  isLoggedIn : boolean;;
  constructor( private router : Router,private loginService : LoginService ) { }
  
  ngOnInit(): void {     
    sessionStorage.length > 0 ? this.loginService.isLoggedIn.next(true) :this.loginService.isLoggedIn.next(false);
    this.loginService.isLoggedIn.subscribe((v) => { 
      this.isLoggedIn = v;
    });
  }
  onLogOut() : void{    
    sessionStorage.clear();
    this.router.navigate(['Login']);
    this.loginService.isLoggedIn.next(false);        
  }  
}
