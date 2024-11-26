import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../../Services/furniture.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CurrencyConverterPipe } from '../../Pipes/currencyConverter/currency-converter.pipe';

@Component({
  selector: 'app-furniture-details',
  standalone: true,
  imports: [CommonModule, CurrencyConverterPipe],
  templateUrl: './furniture-details.component.html',
  styleUrl: './furniture-details.component.scss'
})
export class FurnitureDetailsComponent implements OnInit {
  furniture: any = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private furnitureService: FurnitureService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id'); 
    if (id) {
      this.loadFurnitureDetails(+id); 
    }
  }

  loadFurnitureDetails(id: number): void {
    this.furnitureService.getFurnitureById(id).subscribe({
      next: (data) => {
        this.furniture = data; 

      },
      error: (err) => console.error('Error loading furniture details:', err),
    });
  }

  exit(): void {
    this.router.navigate(['/furnitures']); 
  }
}
