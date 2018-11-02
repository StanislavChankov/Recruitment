
/**
 * Constains user personal and identification information.
 * @export
 * @class UserInfo
 */
export class UserInfo {

    /**
     * The first and last name of the user.
     * @type {string}
     * @memberof UserInfo
     */
    public name: string;

    /**
     * The first name of the user.
     * @type {string}
     * @memberof UserInfo
     */
    public given_name: string;

    /**
     * The fimily name of the user.
     * @type {string}
     * @memberof UserInfo
     */
    public family_name: string;

    /**
     * The birthday of the user.
     * @type {Date}
     * @memberof UserInfo
     */
    public birthdate: Date;

    /**
     * The organization of the user.
     * @type {number}
     * @memberof UserInfo
     */
    public org: number;

    /**
     * The subject of the user. The user identifier.
     * @type {number}
     * @memberof UserInfo
     */
    public sub: number;
}
