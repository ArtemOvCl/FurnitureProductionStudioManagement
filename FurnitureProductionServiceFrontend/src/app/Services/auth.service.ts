import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthDto } from '../Interfaces/auth-item';
import { LoginDto } from '../Interfaces/login-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5221/api/Auth';

  constructor(private http: HttpClient) {}

  login(loginDto: LoginDto): Observable<AuthDto> {
    
    return this.http.post<AuthDto>(`${this.apiUrl}/login`, loginDto).pipe(
      tap((response: AuthDto) => {
        sessionStorage.setItem('token', response.token);
      })
    );
  }

  logout(): void {
    sessionStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return sessionStorage.getItem('token') !== null;
  }

  getRole(): string | null {
    const token = sessionStorage.getItem('token');
    if (token) {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.role; 
    }
    return null;
  }
}
