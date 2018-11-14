import { PersonInsertRequest } from './person-insert-request';

export class UserOrganizationRequest {
    public organizationName: string;
    public person: PersonInsertRequest;
}
