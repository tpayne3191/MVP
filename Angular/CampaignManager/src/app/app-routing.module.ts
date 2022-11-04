import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { WeaponComponent } from './weapon/weapon.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';
import { ComponentDetailsComponent } from './campaigns/component-details/component-details.component';
import { ComponentCardComponent } from './campaigns/component-card/component-card.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'weapon', component: WeaponComponent },
  { path: 'weapon-detail/:id', component: WeaponDetailsComponent },
  { path: 'campaign', component: ComponentCardComponent },
  { path: 'campaign-detail/id', component: ComponentDetailsComponent }
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
