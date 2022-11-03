import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { WeaponService } from '../services/weapon.service';
import Weapon from '../types/weapon.model';

@Component({
  selector: 'app-weapon',
  templateUrl: './weapon.component.html',
  styleUrls: ['./weapon.component.css']
})
export class WeaponComponent implements OnInit {
  weapons$: Observable<Weapon[]> = new Observable<Weapon[]>();

  constructor(private weaponService: WeaponService) { }

  ngOnInit(): void {
    this.weapons$ = this.weaponService.weapon$;
  }
}
