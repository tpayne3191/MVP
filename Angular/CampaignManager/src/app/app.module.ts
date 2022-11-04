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
import { ComponentFormComponent } from './campaigns/component-form/component-form.component';
import { ComponentTableComponent } from './campaigns/component-table/component-table.component';
import { ComponentCardComponent } from './campaigns/component-card/component-card.component';
import { HomeComponent } from './home/home.component';
import { ComponentDetailsComponent } from './campaigns/component-details/component-details.component';

@NgModule({
  declarations: [
    AppComponent,
    WeaponComponent,
    WeaponTableComponent,
    WeaponTableRowComponent,
    WeaponDetailsComponent,
    WeaponFormComponent,
    ComponentDetailsComponent,
    ComponentFormComponent,
    ComponentTableComponent,
    ComponentCardComponent,
    HomeComponent
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
