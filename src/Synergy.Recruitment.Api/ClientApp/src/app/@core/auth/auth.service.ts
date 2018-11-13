import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient, HttpErrorResponse } from '@angular/common/http';

import { of as observableOf } from 'rxjs/observable/of';
import 'rxjs/add/observable/fromEvent';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { String } from 'typescript-string-operations';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NbAuthResult, NbAuthStrategy, NbAuthSimpleToken } from '@nebular/auth';

import { roleActions  } from '../../@shared/configs/role-actions.config';
import { apiUrls } from '../../../environments/environment';
import { TokenResponse, PersonInsertRequest, UserInfo } from '../../@shared/data-models';
import { AbstractAuthService } from '../abstract/abstract-auth.service';
import { AuthConstants, ErrorMessagesConstants, StorageConstants } from '../../@shared/constants';
import { UserStorage, TokenStorage } from '../storages/index';
import { UserFactory } from '../../@shared/factories/user-factory';
import { debug } from 'util';

@Injectable()
export class AuthService
    extends NbAuthStrategy
    implements AbstractAuthService {

    constructor(
        private http: HttpClient,
        private tokenStorage: TokenStorage,
        private userStorage: UserStorage,
        private jwtHelper: JwtHelperService,
    ) {
        super();
    }

    public authenticate(login: any): Observable<NbAuthResult> {
        debugger;
        let headers: HttpHeaders = new HttpHeaders();
        localStorage.removeItem(StorageConstants.accessToken);
        this.userStorage.clearAll();

        const params = new HttpParams()
            .set('grant_type', AuthConstants.grant_type)
            .set('client_id', AuthConstants.client_id)
            .set('client_secret', AuthConstants.client_secret)
            .set('scope', AuthConstants.scopes)
            .set('username', login.email)
            .set('password', login.password);

        headers = headers.set('Content-Type', 'application/x-www-form-urlencoded');

        return this.http
            .post<TokenResponse>(apiUrls.identity.token, params, { headers })
            .map((tokenResponse) => {
                if (!tokenResponse.access_token) {
                    const failAuthResult = new NbAuthResult(false);

                    return failAuthResult;
                }

                this.tokenStorage.setToken(tokenResponse);

                const access_token = new NbAuthSimpleToken(tokenResponse.access_token, 'addValidOwner');

                const successAuthResult = new NbAuthResult(
                    true,
                    tokenResponse,
                    'pages/iot-dashboard',
                    undefined,
                    undefined,
                    access_token);

                return successAuthResult;
            })
            .flatMap(() => this.authorize())
            .catch((res: HttpErrorResponse) => {
                console.error(res.message);

                return Observable.throw(res);
            });
    }

    public getUserInfo(): Observable<UserInfo> {
        return this.http
            .get(apiUrls.identity.userInfo)
            .map((res: UserInfo) => res);
    }

    public register(data?: any): Observable<NbAuthResult> {
        const userOrgInsert = UserFactory.getRequest(data);

        let headers: HttpHeaders = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json' );

        return this.http
                .post(apiUrls.identity.register, userOrgInsert, { headers })
                .map(res => {
                    return new NbAuthResult(true, undefined, 'pages/iot-dashboard');
                });
    }

    public authorize(): Observable<NbAuthResult> {
        return this.getUserInfo()
                    .map(userInfo => {
                        this.userStorage.setUserInfo(userInfo);
                    })
                    .flatMap(() => {
                        const userId: number = this.userStorage.getUserInfo().sub;
                        const getActionsUrl: string = String.Format(apiUrls.identity.actions, userId);

                        return this.http
                        .get(getActionsUrl)
                        .map((res: number) => {
                            this.userStorage.setUserActions(res);

                            return new NbAuthResult(true, undefined, 'pages/iot-dashboard');
                        });
                    });
    }

    public isAuthenticated(): boolean {
        const token: string = this.tokenStorage.getToken();

        return !this.jwtHelper.isTokenExpired(token);
    }

    public isAuthorized(requestedUrl: string): boolean {
        if (!this.isAuthenticated()) {
            return false;
        }

        const requiredRoleAction: number = this.getRequiredRoleAction(requestedUrl);
        const requiredRoleActionFlag: number = 1 << requiredRoleAction;
        const userActions: number = this.userStorage.getUserActions();

        if ((requiredRoleActionFlag & userActions) > 0) {
            return true;
        }

        return false;
    }

    private getRequiredRoleAction(requestedUrl?: string): number {
        if (requestedUrl) {
            const actionByUrl = roleActions.find(a => a.url === requestedUrl);
            if (actionByUrl) {
                return actionByUrl.actionEnum;
            }
        }

        throw new Error(ErrorMessagesConstants.nameOrUlrNotProvided);
    }

  //#region Not implemented

    requestPassword(data?: any): Observable<NbAuthResult> {
        return observableOf(this.createDummyResult(data));
    }

    refreshToken(): Observable<NbAuthResult> {
        return observableOf(this.createDummyResult());
    }

    resetPassword(data?: any): Observable<NbAuthResult> {
        return observableOf(this.createDummyResult(data));
    }

    logout(data?: any): Observable<NbAuthResult> {
        return observableOf(this.createDummyResult(data));
    }

    protected createDummyResult(data?: any): NbAuthResult {
        // if (this.getConfigValue('alwaysFail')) {
        // TODO we dont call tokenService clear during logout in case result is not success
        return new NbAuthResult(false,
            this.createFailResponse(data),
            null,
            ['Something went wrong.']);

            // TODO is it missed messages here, is it token should be defined
            // return new NbAuthResult(true, this.createSuccessResponse(data), '/', ['Successfully logged in.']);
        // }
    }

    //#endregion
}
