import { Component } from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, Event as RouterEvent } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RouterInterCeptor } from './Services/router.interceptor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CollegeAngular'; 
  loading = true;
  constructor(private router: Router,private routerinnter: RouterInterCeptor) {
    this.routerinnter.loading.subscribe((v) => {      
      console.log(v);  
      this.loading = v;
    });
  }


 
}