import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import { Observable } from 'rxjs';
import { PlayerService } from 'src/app/services/player.service';
import Player from 'src/app/types/player.model';

@Component({
  selector: 'app-player-form',
  templateUrl: './player-form.component.html',
  styleUrls: ['./player-form.component.css']
})
export class PlayerFormComponent implements OnInit {
  @Output() playerSubmitted: EventEmitter<Player> =
    new EventEmitter<Player>();
  @Input() playerModel: Player = {} as Player;

  players$: Observable<Player[]> = new Observable<Player[]>();

  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.players$ = this.playerService.player$;
  }

  handleSubmit() {
    this.playerSubmitted.emit(this.playerModel);
  }

}
