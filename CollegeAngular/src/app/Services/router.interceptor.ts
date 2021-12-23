import { Injectable } from '@angular/core';
import { Router, Event as RouterEvent, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RouterInterCeptor  {
  public loading = new BehaviorSubject(false);
  constructor(public router: Router) {     
    router.events.subscribe((event: RouterEvent) => {
        this.navigationInterceptor(event);
    });
  }
   // Shows and hides the loading spinner during RouterEvent changes
   navigationInterceptor(event: RouterEvent): void {
    if (event instanceof NavigationStart) {
       this.loading.next(true);
    }
    if (event instanceof NavigationEnd) {
      setTimeout(() => { // here
        this.loading.next(false);
      }, 800);
    }

    // Set loading state to false in both of the below events to hide the spinner in case a request fails
    if (event instanceof NavigationCancel) {
      setTimeout(() => { // here
        this.loading.next(false);
      }, 800);
    }
    if (event instanceof NavigationError) {
      setTimeout(() => { // here
        this.loading.next(false);
      }, 800);
    }
  }
}
