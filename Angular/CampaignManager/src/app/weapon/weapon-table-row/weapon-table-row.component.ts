import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import { Router } from '@angular/router';
import { AuthServiceService } from '../../services/auth-service.service';
import Weapon from 'src/app/types/weapon.model';

@Component({
  selector: '[app-weapon-table-row]',
  templateUrl: './weapon-table-row.component.html',
  styleUrls: ['./weapon-table-row.component.css']
})
export class WeaponTableRowComponent {
  @Output() clicked: EventEmitter<[Weapon, Operation]> = new EventEmitter<[Weapon, Operation]>();
  @Input() weapon : Weapon = {} as Weapon;
  Op = Operation;

  constructor(private authServiceService: AuthServiceService, private router: Router) { }

  handleClick(operation: Operation): void {
    this.clicked.emit([this.weapon, operation]);
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
