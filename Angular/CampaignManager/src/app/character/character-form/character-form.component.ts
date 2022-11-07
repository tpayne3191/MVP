import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { CharacterService } from 'src/app/services/character.service';
import Character from 'src/app/types/character.model';

@Component({
  selector: 'app-character-form',
  templateUrl: './character-form.component.html',
  styleUrls: ['./character-form.component.css']
})
export class CharacterFormComponent implements OnInit {
  @Output() characterSubmitted: EventEmitter<Character> =
    new EventEmitter<Character>();
  @Input() characterModel: Character = {} as Character;

  characters$: Observable<Character[]> = new Observable<Character[]>();

  constructor(private characterService: CharacterService) { }

  ngOnInit(): void {
    this.characters$ = this.characterService.characters$;
  }

  handleSubmit() {
    this.characterSubmitted.emit(this.characterModel);
  }

}
