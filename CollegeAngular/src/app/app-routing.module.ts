import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClassComponent } from './Components/class/class.component';
import { ClasseditComponent } from './Components/class/Classedit/classedit.component';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { NotFoundComponent } from './Components/Shared/not-found/not-found.component';
import { UserComponent } from './Components/user/user.component';
import { AuthService } from './Services/auth.service';

const routes: Routes = [
   {path:"",component:HomeComponent,canActivate:[AuthService]}
  ,{path:"User",component:UserComponent,canActivate:[AuthService]}
  ,{path:"Class",children:[
                            {path:"", component: ClassComponent ,canActivate:[AuthService]}
                            ,{path:"Create", component: ClasseditComponent ,canActivate:[AuthService]}
                            ,{path:"Edit/:id", component: ClasseditComponent ,canActivate:[AuthService]}
                          ]
    }
  ,{path:"Login",component: LoginComponent}
  ,{path:"**",component: NotFoundComponent,canActivate:[AuthService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[AuthService]
})
export class AppRoutingModule { }
