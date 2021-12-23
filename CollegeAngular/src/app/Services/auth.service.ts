import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate {
  constructor(private toaster : ToastrService,private route :Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {      
      if(sessionStorage.length > 0)
         return true;
      else
      {      
        this.toaster.error("Access denaid!!");
        this.route.navigate(['Login']);
        return false;
      }
  }
}
