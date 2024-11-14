import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BottomNavComponent } from '../bottom-nav/bottom-nav.component';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-furnitures-page',
  standalone: true,
  imports: [CommonModule, BottomNavComponent],
  templateUrl: './furnitures-page.component.html',
  styleUrl: './furnitures-page.component.scss'
})
export class FurnituresPageComponent {
  userRole: string | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.userRole = this.authService.getRole();
  }
}
