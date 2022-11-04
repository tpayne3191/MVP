import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { WeaponComponent } from './weapon/weapon.component';
import { HomeComponent } from './home/home.component';
import { CharacterComponent } from './character/character.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'weapon', component: WeaponComponent },
  { path: 'character', component: CharacterComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    [RouterModule.forRoot(routes)]
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
