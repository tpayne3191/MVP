import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import Character from '../types/character.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private http: HttpClient) {}
  private url = 'https://localhost:5001/api/characters';

  // Load the initial data as an Observable
  characters$: Observable<Character[]> = this.http.get<Character[]>(this.url);

  delete(character: Character): Observable<null> {
    return this.http.delete<null>(this.url + '/' + character.id);
  }

  update(character: Character): Observable<Character> {
    return this.http.put<Character>(this.url + '/', character);
  }

  create(character: Character): Observable<Character> {
    return this.http.post<Character>(this.url, character);
  }
}
