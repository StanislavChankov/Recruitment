import { Observable } from 'rxjs';

import { Candidate } from '../../@shared/data-models/candidates/Candidate';

export declare abstract class CandidateBaseService {
    abstract getCandidatesStatus(): Observable<Array<Candidate>>;
}
