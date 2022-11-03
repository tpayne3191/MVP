import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import Weapon from '../types/weapon.model';

@Injectable({
  providedIn: 'root'
})
export class WeaponService {

  constructor(private http: HttpClient) {}
  private url = 'https://localhost:5001/api/weapons';

  // Load the initial data as an Observable
  weapon$: Observable<Weapon[]> = this.http.get<Weapon[]>(this.url);

  delete(weapon: Weapon): Observable<null> {
    return this.http.delete<null>(this.url + '/' + weapon.id);
  }

  update(weapon: Weapon): Observable<Weapon> {
    return this.http.put<Weapon>(this.url + '/' + weapon.id, weapon);
  }

  create(weapon: Weapon): Observable<Weapon> {
    return this.http.post<Weapon>(this.url, weapon);
  }
}
