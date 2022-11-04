import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import Player from 'src/app/types/player.model';

@Component({
  selector: '[app-player-table-row]',
  templateUrl: './player-table-row.component.html',
  styleUrls: ['./player-table-row.component.css']
})
export class PlayerTableRowComponent {
  @Output() clicked: EventEmitter<[Player, Operation]> = new EventEmitter<[Player, Operation]>();
  @Input() player : Player = {} as Player;
  Op = Operation;

  handleClick(operation: Operation): void {
    this.clicked.emit([this.player, operation]);
  }
}
