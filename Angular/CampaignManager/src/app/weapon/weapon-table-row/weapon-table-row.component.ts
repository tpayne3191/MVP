import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import Weapon from 'src/app/types/weapon.model';

@Component({
  selector: 'app-weapon-table-row',
  templateUrl: './weapon-table-row.component.html',
  styleUrls: ['./weapon-table-row.component.css']
})
export class WeaponTableRowComponent {
  @Output() clicked: EventEmitter<[Weapon, Operation]> = new EventEmitter<[Weapon, Operation]>();
  @Input() weapon : Weapon = {} as Weapon;
  Op = Operation;

  handleClick(operation: Operation): void {
    this.clicked.emit([this.weapon, operation]);
  }
}
