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
}
