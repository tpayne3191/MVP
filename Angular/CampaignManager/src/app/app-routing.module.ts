import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { WeaponComponent } from './weapon/weapon.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'weapon', component: WeaponComponent },
  { path: 'weapon-detail/:id', component: WeaponDetailsComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
