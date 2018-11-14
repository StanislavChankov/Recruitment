import { UserOrganizationRequest, PersonInsertRequest } from '../../@shared/data-models';

/**
 * Contains static mapping methods for creating User related instances.
 * @export
 * @class UserFactory
 */
export  class UserFactory {
    /**
     * Instantiates @see UserOrganizationRequest from userOrganization.
     * @static
     * @param {*} userOrganization
     * @returns {UserOrganizationRequest}
     * @memberof UserFactory
     */
    public static getRequest(userOrganization: any): UserOrganizationRequest {
        return {
            organizationName: userOrganization.organization,
            person: {
                emailAddress: userOrganization.email,
                password: userOrganization.password,
                firstName: userOrganization.firstname,
                lastName: userOrganization.lastname,
            } as PersonInsertRequest,
        } as UserOrganizationRequest;
    }
  }
