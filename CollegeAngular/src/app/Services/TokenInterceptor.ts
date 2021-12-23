import { Injectable } from '@angular/core';
import {  HttpRequest,  HttpHandler,  HttpEvent,  HttpInterceptor, HttpErrorResponse} from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { RouterInterCeptor } from './router.interceptor';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService,private route : Router ,private routinter : RouterInterCeptor) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = request.clone({
      url: environment.baseURL + request.url,
      setHeaders: {
        Authorization: `Bearer ${sessionStorage.getItem('token')}`
      }
    });    
    if(!this.routinter.loading.value){      
       this.routinter.loading.next(true);      
    }    
    // return next.handle(request);
    return next.handle(request).pipe( 
      map((res)=>{
        if(this.routinter.loading.value){          
            this.routinter.loading.next(false);
        }         
        return res;
      }), 
      catchError((error: HttpErrorResponse) => {        
        if (error.status !== 401) {            
          if(error.error.message) 
            this.toastr.error(error.error.message);
          else     
             this.toastr.error(error.message);      
        }
        if (error.status == 401) {           
            this.toastr.error("Unauthorized access please log in and try again.");
            this.route.navigate(['Login']);
        }       
        if(this.routinter.loading.value){         
            this.routinter.loading.next(false);          
        }
        return throwError(error);
      })      
    );
  }
}