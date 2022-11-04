import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayerService } from '../services/player.service';
import Player from '../types/player.model';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  players$: Observable<Player[]> = new Observable<Player[]>();

  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.players$ = this.playerService.player$;
  }
}
