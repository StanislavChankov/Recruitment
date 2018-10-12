import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Candidate } from '../../@shared/data-models/candidates/Candidate';
import { CandidateBaseService } from '../abstract/candidate-base.service';
import { apiUrls } from '../../../environments/environment';
import { ErrorBaseService } from '../abstract/error-base.service';
import { ErrorService } from '../services/error.service';

@Injectable()
export class CandidateService implements CandidateBaseService {

  constructor(
    private http: Http,
    private errorService: ErrorService,
    ) {}

  public getCandidatesStatus(): Observable<Array<Candidate>> {
    return this.http
      .get(apiUrls.candidate.getAll)
      .map(response => {
        const candidates: Array<Candidate> = response.json();

        return candidates;
       })
      .catch(this.handleError);
  }

  public handleError (error: Response | any): Observable<never> {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }
}
