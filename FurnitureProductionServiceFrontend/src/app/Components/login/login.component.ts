import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { AuthDto } from '../../DTOs/AuthDTO';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { finalize } from 'rxjs/operators';
import { ErrorResponse } from '../../Interfaces/error-response';

@Component({
  selector: 'app-login',
  standalone: true, 
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: [] 
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup; 
  generalErrorMessage: string = '';
  isLoading: boolean = false; 
  hidePassword: boolean = true;

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

    const loginData = this.loginForm.value;
    this.isLoading = true; 

    this.authService.login(loginData)
      .pipe(
        finalize(() => {
          this.isLoading = false; 
        })
      )
      .subscribe({
        next: (response: AuthDto) => {
          sessionStorage.setItem('token', response.token);
          this.router.navigate(['/home']);
        },
        error: (error) => this.handleError(error)
      });
  }

  private handleError(error: any) {
    const errorData = error?.error as ErrorResponse;

    if (errorData?.errors) {

      Object.keys(errorData.errors).forEach(field => {
        const control = this.loginForm.get(field);
        if (control) {
          control.setErrors({ serverError: errorData.errors![field][0] });
        }
      });
    }

    this.generalErrorMessage = errorData?.message ?? '';
  }
}

