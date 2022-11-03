import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import Player from '../types/player.model';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private url = 'http://localhost:5001/api/players';

  constructor(private httpClient: HttpClient) { }

  players$: Observable<Player[]> = this.httpClient.get<Player[]>(this.url);

}
