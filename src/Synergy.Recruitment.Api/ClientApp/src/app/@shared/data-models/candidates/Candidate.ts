/**
 * The candidate data model to map the candidate result.
 * @export
 * @interface Candidate
 */
export interface Candidate {
    /**
     * The first name of the Candidate.
     * @type {string}
     * @memberof Candidate
     */
    firstName: string;

    /**
     * The last name of the Candidate.
     * @type {string}
     * @memberof Candidate
     */
    lastName: string;

    /**
     * The position that the Candidate applied for.
     * @type {string}
     * @memberof Candidate
     */
    position: string;

    /**
     * The date on which this candidate was last updated.
     * @type {Date}
     * @memberof Candidate
     */
    updatedOn: Date;
}
