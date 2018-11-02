import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { TokenStorage } from '../storages/token-storage';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(public storage: TokenStorage) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.storage.getToken()}`,
        },
      });

    return next.handle(request);
  }
}
