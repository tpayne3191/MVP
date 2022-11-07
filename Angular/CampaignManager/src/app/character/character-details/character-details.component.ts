import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Location } from '@angular/common';
import { CharacterService } from 'src/app/services/character.service';
import Character from 'src/app/types/character.model';

@Component({
  selector: 'app-character-details',
  templateUrl: './character-details.component.html',
  styleUrls: ['./character-details.component.css']
})
export class CharacterDetailsComponent implements OnInit {
  characters$: Observable<Character[]> = new Observable<Character[]>();
  character: Character = {} as Character;
  constructor(
    private characterService: CharacterService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.characterService.characters$.subscribe((characters) => {
      this.character = characters[id - 1];
    });
  }

  goBack(): void {
    this.location.back();
  }

}