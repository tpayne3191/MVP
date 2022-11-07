import { Component, OnInit, Input } from '@angular/core';
import { map, Observable } from 'rxjs';
import { WeaponService } from 'src/app/services/weapon.service';
import { Operation } from '../../types/operation.model';
import { AuthServiceService } from '../../services/auth-service.service';
import Weapon from 'src/app/types/weapon.model';

@Component({
  selector: 'app-weapon-table',
  templateUrl: './weapon-table.component.html',
  styleUrls: ['./weapon-table.component.css']
})
export class WeaponTableComponent implements OnInit {
  @Input() weapon: Weapon = {} as Weapon;
  editedWeapon: Weapon = {} as Weapon;
  weapons$: Observable<Weapon[]> = new Observable<Weapon[]>();

  constructor(private weaponService: WeaponService, private authServiceService: AuthServiceService) { }

  ngOnInit(): void {
    this.weapons$ = this.weaponService.weapon$;
  }

  private mutateWeapons = () => {
    this.weapons$ = this.weapons$.pipe(map((weapons) => weapons));
  }

  handleClicked([weapon, operation]: [Weapon, Operation]) {
    console.log(weapon);
    if (operation === 'edit') {
      this.editedWeapon = { ...weapon };
    } else if (operation === 'delete') {
      this.weaponService.delete(weapon).subscribe(() => {
        this.mutateWeapons();
      });
    }
  }

  handleWeaponSubmit(weapon: Weapon) {
    console.log(weapon.characterWeapons);
    if (weapon.id) {
      this.weaponService.update(weapon).subscribe(() => {
        this.mutateWeapons();
      });
    } else {
      this.weaponService.create(weapon).subscribe(() => {
        this.mutateWeapons();
      });
    }
    let emptyWeapon: Weapon = {} as Weapon;
    this.editedWeapon = {...emptyWeapon }
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
