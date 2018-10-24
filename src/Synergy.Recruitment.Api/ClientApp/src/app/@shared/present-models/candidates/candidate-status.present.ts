
/**
 * The candidate status presentation model to show the candidate status.
 * @export
 * @class CandidateStatusPresent
 */
export class CandidateStatusPresent {
    /**
     * The candidate's unique identifier.
     * @type {number}
     * @memberof CandidateStatusPresent
     */
    id: number;

    /**
     * The first name of the Candidate.
     * @type {string}
     * @memberof CandidateStatusPresent
     */
    firstName: string;

    /**
     * The last name of the Candidate.
     * @type {string}
     * @memberof CandidateStatusPresent
     */
    lastName: string;

    /**
     * The position that the Candidate applied for.
     * @type {string}
     * @memberof CandidateStatusPresent
     */
    position: string;

    /**
     * The months, days, hours or seconds from the last update of the candidate.
     * @type {string}
     * @memberof CandidateStatusPresent
     */
    updatedBefore: string;
}
