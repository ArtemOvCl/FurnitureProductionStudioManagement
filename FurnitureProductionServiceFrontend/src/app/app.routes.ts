import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { FurnituresPageComponent } from './Components/furnitures-page/furnitures-page.component';
import { FurnitureDetailsComponent } from './Components/furniture-details/furniture-details.component';
import { AuthGuard } from './Guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  {
    path: 'login',
    loadComponent: () =>
      import('./Components/login/login.component').then(
        (m) => m.LoginComponent
      ),
  },
  {
    path: 'furnitures',
    component: FurnituresPageComponent,
    canActivate: [AuthGuard],
    data: { roles: ['Admin', 'Common', 'Logistician'] }, 
  },
  {
    path: 'furniture/:id',
    component: FurnitureDetailsComponent,
    canActivate: [AuthGuard],
    data: { roles: ['Admin', 'Common', 'Logistician'] },
  },
  { path: '**', component: NotFoundComponent },
];
