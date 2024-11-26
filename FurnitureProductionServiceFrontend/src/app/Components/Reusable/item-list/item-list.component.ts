import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemCardComponent } from '../item-card/item-card.component';
import { FurnitureItem } from '../../../Interfaces/furniture-item';

@Component({
  selector: 'app-item-list',
  standalone: true,
  imports: [CommonModule, ItemCardComponent],
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss'],
})
export class ItemListComponent {
  @Input() items: FurnitureItem[] = [];

  @Output() edit = new EventEmitter<number>();
  @Output() delete = new EventEmitter<number>();
  @Output() details = new EventEmitter<number>();

  handleEdit(id: number): void {
    console.log("fwgwgr");
    this.edit.emit(id);
  }

  handleDelete(id: number): void {
    this.delete.emit(id);
  }

  handleDetails(id: number): void {
    this.details.emit(id);
  }
}
