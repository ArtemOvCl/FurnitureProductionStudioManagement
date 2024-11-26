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

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // Перевіряємо, чи користувач авторизований
    if (!this.authService.isLoggedIn()) {
      // Якщо ні, перенаправляємо на сторінку логіну
      this.router.navigate(['/login']);
      return false;
    }

    // Отримуємо ролі, які дозволені для цього маршруту
    const allowedRoles = route.data['roles'] as string[]; // Масив ролей із data
    const userRole = this.authService.getRole(); // Роль користувача

    if (allowedRoles && !allowedRoles.includes(userRole || '')) {
      // Якщо роль не дозволена, перенаправляємо на головну сторінку
      this.router.navigate(['/']);
      return false;
    }

    // Якщо все гаразд, дозволяємо доступ
    return true;
  }
}
