import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/auth.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  isAuthenticated: boolean = false;
  tokenPayload: any; 

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.isAuthenticated = this.authService.isLoggedIn();

    if (!this.isAuthenticated) {
      this.router.navigate(['/login']);
    } else {

      const token = sessionStorage.getItem('token'); 

      if (token) {

        this.tokenPayload = jwtDecode(token);
        console.log(this.tokenPayload); 
      }
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']); 
  }
}
