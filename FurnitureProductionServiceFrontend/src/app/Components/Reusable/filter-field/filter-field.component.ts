import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-filter-field',
  standalone: true,
  imports: [],
  templateUrl: './filter-field.component.html',
  styleUrl: './filter-field.component.scss'
})
export class FilterFieldComponent {
  @Input() label: string = 'Filter'; 
  @Output() filter = new EventEmitter<void>();

  onFilter() {
    this.filter.emit();
  }
}
