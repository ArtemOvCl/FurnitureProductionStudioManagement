import { Component, EventEmitter, Output, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-search-field',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './search-field.component.html',
  styleUrl: './search-field.component.scss'
})
export class SearchFieldComponent {

  @Input() placeholder: string = 'Search...';
  @Output() search = new EventEmitter<string>();

  onInput(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.search.emit(value); 
  }
}
