import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CharacterService } from '../services/character.service';
import Character from '../types/character.model';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css']
})
export class CharacterComponent implements OnInit {
  characters$: Observable<Character[]> = new Observable<Character[]>();

  constructor(private characterService: CharacterService) { }

  ngOnInit(): void {
    this.characters$ = this.characterService.characters$;
  }
}
