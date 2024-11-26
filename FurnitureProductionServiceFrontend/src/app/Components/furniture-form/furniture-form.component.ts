import { CommonModule } from '@angular/common';
import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-furniture-form',
  templateUrl: './furniture-form.component.html',
  styleUrls: ['./furniture-form.component.scss'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class FurnitureFormComponent implements OnChanges {
  @Input() furnitureData: any = null; 
  @Input() isVisible: boolean = false;
  @Input() isEdit: boolean = false; 

  @Output() close = new EventEmitter<void>();
  @Output() submit = new EventEmitter<FormData>();

  selectedFile: File | null = null;

  ngOnChanges(): void {
    if (!this.furnitureData) {
      this.furnitureData = {
        id: null,
        name: '',
        description: '',
        furnitureCollectionId: null,
        depth: null,
        width: null,
        length: null,
        weight: null,
        maximumLoad: null,
        cost: null
      };
    }
  }

  onSubmit(): void {

    const formData = new FormData();
    Object.keys(this.furnitureData).forEach((key) => {
      if (this.furnitureData[key] !== null && this.furnitureData[key] !== undefined) {

        formData.append(key, this.furnitureData[key]);
      }
    });

    if (this.selectedFile) {
      formData.append('imageFile', this.selectedFile);
    }

    console.log('formData instanceof FormData:', formData instanceof FormData);

    this.submit.emit(formData); 
  }

  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      console.log('File selected:', file.name);
    }
  }

  closeForm(): void {

    this.close.emit();
  }
}
