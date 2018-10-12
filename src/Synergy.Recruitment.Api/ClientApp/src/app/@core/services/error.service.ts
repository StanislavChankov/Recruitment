import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ErrorBaseService } from '../abstract/error-base.service';

@Injectable()
export class ErrorService implements ErrorBaseService {

  constructor() {}

  public handleError (error: Response | any): Observable<never> {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }
}
