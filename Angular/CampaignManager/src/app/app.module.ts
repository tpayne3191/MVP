import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './core/in-memory-data.service';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { WeaponComponent } from './weapon/weapon.component';
import { WeaponTableComponent } from './weapon/weapon-table/weapon-table.component';
import { WeaponTableRowComponent } from './weapon/weapon-table-row/weapon-table-row.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';
import { WeaponFormComponent } from './weapon/weapon-form/weapon-form.component';
import { FormsModule } from '@angular/forms';
import { PlayerComponent } from './player/player.component';
import { PlayerDetailsComponent } from './player/player-details/player-details.component';
import { PlayerFormComponent } from './player/player-form/player-form.component';
import { PlayerTableComponent } from './player/player-table/player-table.component';
import { PlayerTableRowComponent } from './player/player-table-row/player-table-row.component';
import { HomeComponent } from './home/home.component';
import { CharacterComponent } from './character/character.component';

@NgModule({
  declarations: [
    AppComponent,
    WeaponComponent,
    WeaponTableComponent,
    WeaponTableRowComponent,
    WeaponDetailsComponent,
    WeaponFormComponent,
    PlayerComponent,
    PlayerDetailsComponent,
    PlayerFormComponent,
    PlayerTableComponent,
    PlayerTableRowComponent
    HomeComponent,
    CharacterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    // HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
    //   dataEncapsulation: false,
    // }),
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
