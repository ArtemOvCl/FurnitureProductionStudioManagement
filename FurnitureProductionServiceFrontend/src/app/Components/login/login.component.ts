import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { AuthDto } from '../../Interfaces/auth-item';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { ErrorResponse } from '../../Interfaces/error-response';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true, 
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'] 
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup; 
  generalErrorMessage = '';
  isLoading = false; 
  hidePassword = true;

  constructor(
    private authService: AuthService, 
    private router: Router, 
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/home']);
    }

    this.loginForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  login() {
    if (this.loginForm.invalid || this.isLoading) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.isLoading = true; 
    this.authService.login(this.loginForm.value)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: (response: AuthDto) => {
          sessionStorage.setItem('token', response.token);
          this.router.navigate(['/furnitures']);
        },
        error: (error) => this.handleError(error)
      });
  }

  private handleError(error: any) {
    const errorData = error?.error as ErrorResponse;
    if (errorData?.errors) {
      Object.entries(errorData.errors).forEach(([field, messages]) => {
        const control = this.loginForm.get(field);
        if (control) {
          control.setErrors({ serverError: messages[0] });
        }
      });
    }
    this.generalErrorMessage = errorData?.message || '';
  }
}
