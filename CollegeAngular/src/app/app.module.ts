import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './Components/home/home.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Shared/header/header.component';
import { FooterComponent } from './Components/Shared/footer/footer.component';
import { UserComponent } from './Components/user/user.component';
import { UsereditComponent } from './Components/user/useredit/useredit.component';
import { ClassComponent } from './Components/class/class.component';
import { ClasseditComponent } from './Components/class/Classedit/classedit.component';
import { LoginComponent } from './Components/login/login.component';
import { TokenInterceptor } from './Services/TokenInterceptor';
import { NotFoundComponent } from './Components/Shared/not-found/not-found.component';
import { RouterInterCeptor } from './Services/router.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    UserComponent,
    HomeComponent,    
    UsereditComponent,
    ClassComponent, 
    ClasseditComponent, LoginComponent, NotFoundComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule, // for http request
    ModalModule.forRoot(), // for bootstrap dailog
    BrowserAnimationsModule, // required animations module for toaster
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [ {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  },RouterInterCeptor],
  bootstrap: [AppComponent]
})
export class AppModule { }
