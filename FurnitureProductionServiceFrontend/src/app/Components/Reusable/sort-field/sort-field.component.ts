import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-sort-field',
  standalone: true,
  imports: [],
  templateUrl: './sort-field.component.html',
  styleUrl: './sort-field.component.scss'
})
export class SortFieldComponent {
  @Input() label: string = 'Sort by';
  @Output() sort = new EventEmitter<void>();

  onSort() {
    this.sort.emit();
  }
}
