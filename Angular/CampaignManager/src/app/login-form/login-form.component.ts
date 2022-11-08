import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { AuthServiceService } from '../services/auth-service.service';
import User from '../types/user.model';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  user: User = { userName: 'johncitizen', password: 'abc@123' } as User;
  constructor(private authService: AuthServiceService, private router: Router) { }

  handleSubmit() {
    try {
      this.authService.loginPlayerId(this.user.userName, this.user.password, 1).subscribe(
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
