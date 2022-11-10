import { Router } from '@angular/router';
import { PlayerService } from 'src/app/services/player.service';
import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../services/auth-service.service';
import { Observable } from 'rxjs';
import Player from 'src/app/types/player.model';
import User from '../types/user.model';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  user: User = { userName: 'johncitizen', password: 'abc@123' } as User;
  playerId: number = {} as number;
  players$: Observable<Player[]> = new Observable<Player[]>();

  constructor(
    private authService: AuthServiceService,
    private router: Router,
    private playerService: PlayerService
    ) { }

  ngOnInit(): void {
    this.players$ = this.playerService.players$;
  }

  handleSubmit() {
    try {
      this.authService.loginPlayerId(this.user.userName, this.user.password).subscribe(
        res => this.router.navigateByUrl('/'),
        err => {
          alert('username and/or password is incorrect');
          this.user = {} as User;
        },
        () => console.log('HTTP request completed.')
      );
    } catch (error) { }
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/')
  }
  getUsername(): string {
    return this.authService.getUserName() || "";
  }
}
