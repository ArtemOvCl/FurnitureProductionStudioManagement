import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { AuthDto } from '../../DTOs/AuthDTO';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true, 
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  name: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {

    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/home']);
    }
  }

  login() {
    this.authService.login({ name: this.name, password: this.password })
      .subscribe({
        next: (response: AuthDto) => {
          sessionStorage.setItem('token', response.token);
          this.router.navigate(['/home']);
        },
        error: (error) => {
          
          this.errorMessage = error.error.message || "Enter your name and password";
        }
      });
  }
  
}
