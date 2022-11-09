import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayerService } from 'src/app/services/player.service';
import { Operation } from '../../types/operation.model';
import { Location } from '@angular/common';
import Player from 'src/app/types/player.model';
import { map } from 'rxjs/operators';
import { AuthServiceService } from '../../services/auth-service.service';

@Component({
  selector: 'app-player-table',
  templateUrl: './player-table.component.html',
  styleUrls: ['./player-table.component.css']
})
export class PlayerTableComponent implements OnInit {
  @Input() player: Player = {} as Player;
  editedPlayer: Player = {} as Player;
  players$: Observable<Player[]> = new Observable<Player[]>();

  constructor(
    private playerService: PlayerService,
    private location: Location,
    private authServiceService: AuthServiceService
    ) { }


  ngOnInit(): void {
    this.players$ = this.playerService.players$;
  }

  private mutatePlayers = () => {
    this.players$ = this.players$.pipe(map((players) => players));
  }


  handleClicked([player, operation]: [Player, Operation]) {

      if (operation === 'edit') {
        this.editedPlayer = { ...player };
      } else if (operation === 'delete') {
        this.playerService.delete(player).subscribe(() => {
          this.mutatePlayers();
        });
      }

  }

  handlePlayerSubmit(player: Player) {

    if(player.name && player.name.trim().length>0){
      if (player.id) {
        this.playerService.update(player).subscribe(() => {
          this.mutatePlayers();
        });
      } else {
        this.playerService.create(player).subscribe(() => {
          this.mutatePlayers();
        });
      }
      let emptyPlayer: Player = {} as Player;
      this.editedPlayer = {...emptyPlayer }
    }
    else{
      window.alert("Player Name cannot be blank. Please try again.")
    }
  }

  goBack(): void {
    this.location.back();
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}

