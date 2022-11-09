import { Component, OnInit } from '@angular/core';
import { WeaponService } from 'src/app/services/weapon.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import Weapon from 'src/app/types/weapon.model';

@Component({
  selector: 'app-weapon-details',
  templateUrl: './weapon-details.component.html',
  styleUrls: ['./weapon-details.component.css']
})
export class WeaponDetailsComponent implements OnInit {
  weapons$: Observable<Weapon[]> = new Observable<Weapon[]>();
  weapon: Weapon = {} as Weapon;
  constructor(
    private weaponService: WeaponService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.weaponService.weapon$.subscribe((weapons) => {
      this.weapon = weapons.filter(w=>w.id===id)[0];
    });
  }

  goBack(): void {
    this.location.back();
  }

}
