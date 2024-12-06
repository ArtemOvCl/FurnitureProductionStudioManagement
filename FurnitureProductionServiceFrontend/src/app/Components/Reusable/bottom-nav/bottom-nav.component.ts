import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../../Services/auth.service';

import { NavLink } from '../../../Interfaces/nav-link';
import { ShowForRoleDirective } from '../../../directives/ShowForRole/show-for-role.directive';

@Component({
  selector: 'app-bottom-nav',
  standalone: true,
  imports: [MatIconModule, CommonModule, ShowForRoleDirective],
  templateUrl: './bottom-nav.component.html',
  styleUrls: ['./bottom-nav.component.scss']
})
export class BottomNavComponent implements OnInit {
  @Input() role: string = ''; 
  isVisible = true;

  navLinks: NavLink[] = [
    { path: '/furnitures', label: 'Furnitures', icon: 'chair', roles: ['Admin', 'Common', 'Logistician'] },
    { path: '/materials', label: 'Materials', icon: 'category', roles: ['Admin', 'Logistician'] },
    { path: '/manufactures', label: 'Manufactures', icon: 'factory', roles: ['Admin', 'Logistician'] },
    { path: '/employee', label: 'Employee', icon: 'people', roles: ['Admin'] },
    { path: '/furnituresproductions', label: 'Furnitures Productions', icon: 'build', roles: ['Admin', 'Common', 'Logistician'] }
  ];

  filteredLinks: NavLink[] = [];

  constructor(public router: Router, private authService: AuthService) {} 

  ngOnInit() {

    //Choose for directive

    //this.filteredLinks = this.navLinks.filter(link => link.roles.includes(this.role));
  }

  navigate(path: string) {
    this.router.navigate([path]);
  }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
