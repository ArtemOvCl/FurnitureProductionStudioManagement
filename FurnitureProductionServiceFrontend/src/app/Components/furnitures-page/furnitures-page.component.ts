import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../../Services/furniture.service';
import { FurnitureItem } from '../../Interfaces/furniture-item';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../Reusable/header/header.component';
import { ItemListComponent } from '../Reusable/item-list/item-list.component';
import { SearchFieldComponent } from '../Reusable/search-field/search-field.component';
import { SortFieldComponent } from '../Reusable/sort-field/sort-field.component';
import { FilterFieldComponent } from '../Reusable/filter-field/filter-field.component';
import { AddItemButtonComponent } from '../Reusable/add-item-button/add-item-button.component';
import { FurnitureFormComponent } from '../furniture-form/furniture-form.component';
import { BottomNavComponent } from '../Reusable/bottom-nav/bottom-nav.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-furnitures-page',
  templateUrl: './furnitures-page.component.html',
  styleUrls: ['./furnitures-page.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    ItemListComponent,
    SearchFieldComponent,
    SortFieldComponent,
    FilterFieldComponent,
    AddItemButtonComponent,
    FurnitureFormComponent,
    BottomNavComponent,
  ],
})
export class FurnituresPageComponent implements OnInit {
  furnitureList: FurnitureItem[] = [];
  isFormVisible: boolean = false;
  isFormEdit: boolean = false;
  isLoading: boolean = true;
  selectedFurniture: FurnitureItem | null = null;

  constructor(private furnitureService: FurnitureService, private router: Router) {}

  ngOnInit(): void {
    this.loadFurniture();
  }

  loadFurniture(): void {
    this.isLoading = true; // Початок завантаження
    this.furnitureService.getAllFurnitures().subscribe({
      next: (data) => {
        this.furnitureList = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading furniture list:', err);
        this.isLoading = false; 
      },
    });
  }

  handleAdd(): void {
    this.isFormVisible = true;
    this.isFormEdit = false;
  }

  handleEdit(id: number): void {
    this.furnitureService.getFurnitureById(id).subscribe({
      next: (furnitureDetails) => {
        this.selectedFurniture = furnitureDetails;
        this.isFormVisible = true;
        this.isFormEdit = true;
      },
      error: (err) => console.error(`Error loading furniture with ID ${id}:`, err),
    });
  }

  handleFormSubmission(formData: FormData): void {
    if (this.isFormEdit && this.selectedFurniture) {
      this.furnitureService.updateFurniture(this.selectedFurniture.id, formData).subscribe({
        next: () => {
          this.loadFurniture();
          this.closeForm();
        },
        error: (err) => console.error('Error updating furniture:', err),
      });
    } else {
      this.furnitureService.addFurniture(formData).subscribe({
        next: () => {
          this.loadFurniture();
          this.closeForm();
        },
        error: (err) => console.error('Error adding furniture:', err),
      });
    }
  }

  closeForm(): void {
    this.isFormVisible = false;
    this.isFormEdit = false;
    this.selectedFurniture = null;
  }

  handleDelete(id: number): void {
    this.furnitureService.deleteFurnitureById(id).subscribe({
      next: () => {
        this.furnitureList = this.furnitureList.filter((item) => item.id !== id);
      },
      error: (err) => console.error(`Error deleting furniture with ID ${id}:`, err),
    });
  }

  handleFilter(): void {}

  handleSort(): void {}

  handleSearch(): void {}

  handleDetails(id: number): void {
    this.router.navigate(['/furniture', id]);
  }
}
