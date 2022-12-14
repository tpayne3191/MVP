import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import { Observable } from 'rxjs';
import { PlayerService } from 'src/app/services/player.service';
import Player from 'src/app/types/player.model';
import { NgForm } from '@angular/forms';

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
    this.players$ = this.playerService.players$;
  }

  handleSubmit() {
    this.playerSubmitted.emit(this.playerModel);
  }

  resetForm(form: NgForm) {
    form.resetForm();
  }

}
