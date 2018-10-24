import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { CandidateStatus } from '../../@shared/data-models/candidates/candidate-status';
import { CandidateBaseService } from '../abstract/candidate-base.service';
import { apiUrls } from '../../../environments/environment';
import { ErrorService } from '../business-services/error.service';

@Injectable()
export class CandidateService implements CandidateBaseService {

  constructor(
    private http: Http,
    private errorService: ErrorService,
    ) {}

  public getCandidatesStatus(): Observable<Array<CandidateStatus>> {
    return this.http
      .get(apiUrls.candidate.getAll)
      .map(response => {
        const candidates: Array<CandidateStatus> = response.json();

        return candidates;
       })
      .catch(this.errorService.handleError);
  }
}
