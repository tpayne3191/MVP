import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Location } from '@angular/common';
import { CharacterService } from 'src/app/services/character.service';
import Character from 'src/app/types/character.model';
import { AuthServiceService } from 'src/app/services/auth-service.service';
import Player from 'src/app/types/player.model';

@Component({
  selector: 'app-character-details',
  templateUrl: './character-details.component.html',
  styleUrls: ['./character-details.component.css']
})
export class CharacterDetailsComponent implements OnInit {
  characters$: Observable<Character[]> = new Observable<Character[]>();
  character: Character = {} as Character;
  player: Player = {} as Player;

  constructor(
    private characterService: CharacterService,
    private authService: AuthServiceService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.characterService.characters$.subscribe((characters) => {
      this.character = characters.filter(p=>p.id===id)[0];
    });
    this.player.name = this.authService.getUserName();
  }

  goBack(): void {
    this.location.back();
  }

}
