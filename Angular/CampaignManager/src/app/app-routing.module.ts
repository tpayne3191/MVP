import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { WeaponComponent } from './weapon/weapon.component';
import { PlayerComponent } from './player/player.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';
import { ComponentDetailsComponent } from './campaigns/component-details/component-details.component';
import { ComponentCardComponent } from './campaigns/component-card/component-card.component';
import { HomeComponent } from './home/home.component';
import { CharacterComponent } from './character/character.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'weapon', component: WeaponComponent },
  { path: 'player', component: PlayerComponent },
  { path: 'character', component: CharacterComponent },
  { path: 'weapon-detail/:id', component: WeaponDetailsComponent },
  { path: 'campaign', component: ComponentCardComponent },
  { path: 'campaign-detail/id', component: ComponentDetailsComponent }
  // { path: 'campaign', component: CampaignComponent },
  // { path: 'player', component: PlayerComponent },
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
