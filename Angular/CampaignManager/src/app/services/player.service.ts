import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import Player from '../types/player.model';

@Injectable({
  providedIn: 'root',
})

export class PlayerService {
  constructor(private http: HttpClient) {}
  private url = 'https://localhost:5001/api/players';

  // Load the initial data as an Observable
  player$: Observable<Player[]> = this.http.get<Player[]>(this.url);

  delete(player: Player): Observable<null> {
    return this.http.delete<null>(this.url + '/' + player.id);
  }

  update(player: Player): Observable<Player> {
    return this.http.put<Player>(this.url + '/' + player.id, player);
  }

  create(player: Player): Observable<Player> {
    return this.http.post<Player>(this.url, player);
  }
}
