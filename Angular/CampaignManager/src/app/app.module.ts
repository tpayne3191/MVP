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

@NgModule({
  declarations: [
    AppComponent,
    WeaponComponent,
    WeaponTableComponent,
    WeaponTableRowComponent,
    WeaponDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
      dataEncapsulation: false,
    }),
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
