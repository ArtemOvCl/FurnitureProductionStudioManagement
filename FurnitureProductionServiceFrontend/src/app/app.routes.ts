import { Routes } from '@angular/router';
     import { HomeComponent } from './Components/home/home.component';
     import { LoginComponent } from './Components/login/login.component';

     export const routes: Routes = [
       { path: '', redirectTo: '/login', pathMatch: 'full' },
       { path: 'home', component: HomeComponent },
       { path: 'login', component: LoginComponent },
       { path: '**', component: HomeComponent }
     ];