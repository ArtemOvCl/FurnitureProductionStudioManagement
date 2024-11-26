import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-item-button',
  templateUrl: './add-item-button.component.html',
  styleUrls: ['./add-item-button.component.scss'],
  standalone: true,
})
export class AddItemButtonComponent {
  @Input() iconPath: string = 'assets/icons/add.png'; 
  @Output() clickAdd = new EventEmitter<void>();

  onClick() {
    this.clickAdd.emit();
  }
}
