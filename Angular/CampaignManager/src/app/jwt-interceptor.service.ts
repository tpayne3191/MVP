import { AuthServiceService } from './services/auth-service.service';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthServiceService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add auth header with jwt if account is logged in and request is to the api url
    const account = this.authService.getToken();
    const isApiUrl = request.url.startsWith("https://localhost:5001/api");
    if (this.authService.isLoggedIn() && isApiUrl) {
      request = request.clone({
        setHeaders: { Authorization: `Bearer ${account.token}` }
      });
    }

    return next.handle(request);
  }
}
