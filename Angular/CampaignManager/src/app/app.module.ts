import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './core/in-memory-data.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { WeaponComponent } from './weapon/weapon.component';
import { WeaponTableComponent } from './weapon/weapon-table/weapon-table.component';
import { WeaponTableRowComponent } from './weapon/weapon-table-row/weapon-table-row.component';
import { WeaponDetailsComponent } from './weapon/weapon-details/weapon-details.component';
import { WeaponFormComponent } from './weapon/weapon-form/weapon-form.component';
import { FormsModule } from '@angular/forms';
import { ComponentFormComponent } from './campaigns/component-form/component-form.component';
import { ComponentCardComponent } from './campaigns/component-card/component-card.component';
import { HomeComponent } from './home/home.component';
import { ComponentDetailsComponent } from './campaigns/component-details/component-details.component';
import { PlayerComponent } from './player/player.component';
import { PlayerDetailsComponent } from './player/player-details/player-details.component';
import { PlayerFormComponent } from './player/player-form/player-form.component';
import { PlayerTableComponent } from './player/player-table/player-table.component';
import { PlayerTableRowComponent } from './player/player-table-row/player-table-row.component';
import { CharacterComponent } from './character/character.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { AuthGuard } from './guards/auth.guard';
import { JwtInterceptor } from './jwt-interceptor.service';
import { CampaignComponent } from './campaigns/campaign.component';

import { CharacterTableComponent } from './character/character-table/character-table.component';
import { CharacterTableRowComponent } from './character/character-table-row/character-table-row.component';
import { CharacterDetailsComponent } from './character/character-details/character-details.component';
import { CharacterFormComponent } from './character/character-form/character-form.component';
import { CampaignsCharactersComponent } from './campaigns/campaigns-characters/campaigns-characters.component';

@NgModule({
  declarations: [
    AppComponent,
    WeaponComponent,
    WeaponTableComponent,
    WeaponTableRowComponent,
    WeaponDetailsComponent,
    WeaponFormComponent,
    CampaignComponent,
    ComponentDetailsComponent,
    ComponentFormComponent,
    ComponentCardComponent,
    HomeComponent,
    PlayerComponent,
    PlayerDetailsComponent,
    PlayerFormComponent,
    PlayerTableComponent,
    PlayerTableRowComponent,
    HomeComponent,
    CharacterComponent,
    LoginFormComponent,
    CharacterTableComponent,
    CharacterTableRowComponent,
    CharacterDetailsComponent,
    CharacterFormComponent,
    CampaignsCharactersComponent
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
  providers: [AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
