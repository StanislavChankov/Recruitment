import { CandidateStatusPresent } from '../present-models/candidates/candidate-status.present';
import { CandidateStatus } from '../data-models/candidates/candidate-status';

/**
 * Contains static mapping methods to map @see Candidate related instances.
 * @export
 * @class CandidateFactory
 */
export  class CandidateFactory {

    /**
     * Creates @see CandidateStatusPresent model from @see CandidateStatus.
     * @static
     * @param {CandidateStatus} candidate
     * @returns {CandidateStatusPresent}
     * @memberof CandidateFactory
     */
    public static getPresent(candidate: CandidateStatus): CandidateStatusPresent {
      return {
        id: candidate.id,
        firstName: candidate.firstName,
        lastName: candidate.lastName,
        position: candidate.position,
        updatedBefore: '',
      } as CandidateStatusPresent;
    }
  }
