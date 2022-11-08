import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthServiceService } from './services/auth-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Home Page';

  constructor(private authServiceService: AuthServiceService, private router: Router) { }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
  logout() {
    this.authServiceService.logout();
    this.router.navigateByUrl('/')
  }

  getPlayerId() {
    const playerId = this.authServiceService.getPlayerId();
    console.log('player ID: ', playerId);
  }

  getUsername(): string {
    console.log('User Name: ', this.authServiceService.getUserName());

    return this.authServiceService.getUserName() || "";
  }
}
