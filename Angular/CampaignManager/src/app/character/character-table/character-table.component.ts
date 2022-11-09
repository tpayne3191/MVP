import { Component, Input, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CharacterService } from 'src/app/services/character.service';
import Character from 'src/app/types/character.model';
import { Location } from '@angular/common';
import { Operation } from 'src/app/types/operation.model';
import { AuthServiceService } from 'src/app/services/auth-service.service';

@Component({
  selector: 'app-character-table',
  templateUrl: './character-table.component.html',
  styleUrls: ['./character-table.component.css']
})

export class CharacterTableComponent implements OnInit {
  @Input() character: Character = {} as Character;
  editedCharacter: Character = {} as Character;
  characters$: Observable<Character[]> = new Observable<Character[]>();

  constructor(
    private characterService: CharacterService,
    private authServiceService: AuthServiceService,
    private location: Location
    ) { }

  ngOnInit(): void {
    this.characters$ = this.characterService.characters$;
  }

  private mutateCharacters = () => {
    this.characters$ = this.characters$.pipe(map((characters) => characters));
  }


  handleClicked([character, operation]: [Character, Operation]) {
    if (operation === 'edit') {
      this.editedCharacter = { ...character };
    } else if (operation === 'delete') {
      this.characterService.delete(character).subscribe(() => {
        this.mutateCharacters();
      });
    }
  }

  handleCharacterSubmit(character: Character) {
      if (character.id) {
      this.characterService.update(character).subscribe(() => {
        this.mutateCharacters();
      });
    } else {
      this.characterService.create(character).subscribe(() => {
        this.mutateCharacters();
      });
    }
    let emptyCharacter: Character = {} as Character;
    this.editedCharacter = {...emptyCharacter }
  }

  goBack(): void {
    this.location.back();
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}