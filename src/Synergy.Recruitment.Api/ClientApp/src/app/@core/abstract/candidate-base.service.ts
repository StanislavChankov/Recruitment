import { Observable } from 'rxjs';

import { CandidateStatus } from '../../@shared/data-models/candidates/candidate-status';

export declare abstract class CandidateBaseService {
    abstract getCandidatesStatus(): Observable<Array<CandidateStatus>>;
}
