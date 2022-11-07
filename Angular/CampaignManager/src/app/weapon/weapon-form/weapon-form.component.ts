import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import { Observable } from 'rxjs';
import { WeaponService } from 'src/app/services/weapon.service';
import Weapon from 'src/app/types/weapon.model';

@Component({
  selector: 'app-weapon-form',
  templateUrl: './weapon-form.component.html',
  styleUrls: ['./weapon-form.component.css']
})
export class WeaponFormComponent implements OnInit {
  @Output() weaponSubmitted: EventEmitter<Weapon> =
    new EventEmitter<Weapon>();
  @Input() weaponModel: Weapon = {} as Weapon;

  weapons$: Observable<Weapon[]> = new Observable<Weapon[]>();

  constructor(private weaponService: WeaponService) { }

  ngOnInit(): void {
    this.weapons$ = this.weaponService.weapon$;
  }

  handleSubmit() {
    this.weaponSubmitted.emit(this.weaponModel);
  }
}
