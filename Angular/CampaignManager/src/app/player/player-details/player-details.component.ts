import { Component, OnInit } from '@angular/core';
import { PlayerService } from 'src/app/services/player.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import Player from 'src/app/types/player.model';

@Component({
  selector: 'app-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.css']
})
export class PlayerDetailsComponent implements OnInit {
  players$: Observable<Player[]> = new Observable<Player[]>();
  player: Player = {} as Player;
  constructor(
    private playerService: PlayerService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.playerService.player$.subscribe((players) => {
      this.player = players[id - 1];
    });
  }

  goBack(): void {
    this.location.back();
  }

}
