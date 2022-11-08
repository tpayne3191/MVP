import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import jwt_decode from 'jwt-decode';
import User from '../types/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http: HttpClient) { }
  private url = 'https://localhost:5001/api/authentications/login';

  login(userName: string, password: string) {
    return this.http.post<User>(this.url, { userName, password }).pipe(tap(res => {
      this.setSession(res);
    }))
  }

  loginPlayerId(userName: string, password: string, playerId: number) {
    return this.http.post<User>(this.url + '/' + `${playerId}`, { userName, password }).pipe(tap(res => {
      this.setSession(res);
    }))
  }

  private setSession(authResult: any) {
    localStorage.setItem('id_token', authResult.token);
  }

  logout() {
    localStorage.removeItem('id_token');
  }

  public getUserName(): string {
    try {
      let token = jwt_decode(localStorage.getItem('id_token') || '') as any;
      console.log('token: ', token);
      return token!.fullName;
    }
    catch (error) {
      return '';
    }
  }

  public getPlayerId(): number {
    try {
      let token = jwt_decode(localStorage.getItem('id_token') || '') as any;
      console.log('token: ', token);
      return token!.playerId;
    }
    catch (error) {
      return 0;
    }
  }

  public isLoggedIn() {
    if(localStorage.getItem('id_token')) {
      return true;
    }
    return false;
  }

  getToken() {
    const token = localStorage.getItem('id_token');
    return { token: token }
  }
}

