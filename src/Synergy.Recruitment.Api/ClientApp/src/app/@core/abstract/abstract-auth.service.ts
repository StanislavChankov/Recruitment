import { Observable } from 'rxjs/Rx';
import { NbAuthResult } from '@nebular/auth';

import { ActionTypes } from '../../@shared/enums/action-types.enum';
import { UserInfo } from '../../@shared/data-models';


/**
 * Provides authentication and authorization abstractions.
 * @export
 * @abstract
 * @class AbstractAuthService
 */
export declare abstract class AbstractAuthService {
    public abstract authorize(): Observable<NbAuthResult>;
    public abstract isAuthenticated(): boolean;
    public abstract isAuthorized(requestedUrl: string): boolean;
    public abstract getUserInfo(): Observable<UserInfo>;
}
