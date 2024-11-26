import { Component, Input, Output, EventEmitter } from '@angular/core';

import { FurnitureItem } from '../../../Interfaces/furniture-item';
import { ShowForRoleDirective } from '../../../directives/show-for-role.directive';

@Component({
  selector: 'app-item-card',
  standalone: true,
  imports: [ShowForRoleDirective],
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss'],
})
export class ItemCardComponent {
  @Input() data!: FurnitureItem;

  @Output() edit = new EventEmitter<number>();
  @Output() delete = new EventEmitter<number>();
  @Output() details = new EventEmitter<number>();

  onEdit(): void {
    console.log("fwfg");
    this.edit.emit(this.data.id);
  }

  onDelete(): void {
    this.delete.emit(this.data.id);
  }

  onDetails(): void {
    this.details.emit(this.data.id);
  }
}
