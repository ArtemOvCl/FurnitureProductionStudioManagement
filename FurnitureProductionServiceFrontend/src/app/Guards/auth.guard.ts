import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {

    if (!this.authService.isLoggedIn()) {

      this.router.navigate(['/login']);
      return false;
    }

    const allowedRoles = route.data['roles'] as string[];
    const userRole = this.authService.getRole(); 

    if (allowedRoles && !allowedRoles.includes(userRole || '')) {

      this.router.navigate(['/']);
      return false;
    }

    return true;
  }
}
