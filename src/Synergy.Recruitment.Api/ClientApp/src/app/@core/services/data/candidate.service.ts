import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { CandidateStatus } from '../../../@shared/data-models/candidates/candidate-status';
import { CandidateBaseService } from '../../abstract/candidate-base.service';
import { apiUrls } from '../../../../environments/environment';
import { ErrorService } from '../business/error.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CandidateService implements CandidateBaseService {

  constructor(
    private http: HttpClient,
    private errorService: ErrorService,
    ) {}

  public getCandidatesStatus(): Observable<Array<CandidateStatus>> {
    return this.http
      .get(apiUrls.candidate.getAll)
      .map((candidates: Array<CandidateStatus>) => candidates)
      .catch(this.errorService.handleError);
  }
}
