import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthDto } from '../DTOs/AuthDTO';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5221/api/Auth'; 

  constructor(private http: HttpClient) { }

  login(loginDto: { name: string; password: string }): Observable<AuthDto> {
    ;
    return this.http.post<AuthDto>(`${this.apiUrl}/login`, loginDto);
  }

  logout(): void {
    sessionStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return sessionStorage.getItem('token') !== null;
  }
}
