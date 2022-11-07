import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { WeaponComponent } from './weapon/weapon.component';
import { PlayerComponent } from './player/player.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';
import { HomeComponent } from './home/home.component';
import { CharacterComponent } from './character/character.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { AuthGuard } from './guards/auth.guard';
import { PlayerDetailsComponent } from './player/player-details/player-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'weapon', component: WeaponComponent, canActivate: [AuthGuard]  },
  { path: 'player', component: PlayerComponent },
  { path: 'player-detail/:id', component: PlayerDetailsComponent },
  { path: 'character', component: CharacterComponent },
  { path: 'weapon-detail/:id', component: WeaponDetailsComponent },
  { path: 'login', component: LoginFormComponent },
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
