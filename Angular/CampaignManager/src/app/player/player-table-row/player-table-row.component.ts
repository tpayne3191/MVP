import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import Player from 'src/app/types/player.model';
import { Router } from '@angular/router';
import { AuthServiceService } from '../../services/auth-service.service';

@Component({
  selector: '[app-player-table-row]',
  templateUrl: './player-table-row.component.html',
  styleUrls: ['./player-table-row.component.css']
})
export class PlayerTableRowComponent {
  @Output() clicked: EventEmitter<[Player, Operation]> = new EventEmitter<[Player, Operation]>();
  @Input() player : Player = {} as Player;
  Op = Operation;

  constructor(
    private authServiceService: AuthServiceService,
    private router: Router
    ) { }

  handleClick(operation: Operation): void {
    this.clicked.emit([this.player, operation]);
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
