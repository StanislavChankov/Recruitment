/**
 * The candidate status data model to map the candidate status result.
 * @export
 * @interface CandidateStatus
 */
export interface CandidateStatus {

    /**
     * The candidate's unique identifier.
     * @type {number}
     * @memberof CandidateStatus
     */
    id: number;

    /**
     * The first name of the Candidate.
     * @type {string}
     * @memberof CandidateStatus
     */
    firstName: string;

    /**
     * The last name of the Candidate.
     * @type {string}
     * @memberof CandidateStatus
     */
    lastName: string;

    /**
     * The position that the Candidate applied for.
     * @type {string}
     * @memberof CandidateStatus
     */
    position: string;

    /**
     * The date on which this candidate was last updated.
     * @type {Date}
     * @memberof CandidateStatus
     */
    updatedOn: Date;
}
