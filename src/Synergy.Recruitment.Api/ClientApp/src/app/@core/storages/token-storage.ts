import { Injectable } from '@angular/core';

import { String } from 'typescript-string-operations';

import { StorageConstants, ErrorMessagesConstants } from '../../@shared/constants';
import { TokenResponse } from '../../@shared/data-models';

@Injectable()
export class TokenStorage {
    /**
   * Sets the access_token with its metadata in the local storage by from the @param TokenResponse.
   *
   * @example setToken(new TokenResponse());
   *
   */
  public setToken(tokenResponse: TokenResponse): void {
    if (tokenResponse.access_token) {
        localStorage.setItem(StorageConstants.accessToken, tokenResponse.access_token);
        localStorage.setItem(StorageConstants.accessTokenStoredAt, '' + Date.now());

        if (tokenResponse.expires_in) {
            const expiresInMilliSeconds = tokenResponse.expires_in * 1000;
            const now = new Date();
            const expiresAt = now.getTime() + expiresInMilliSeconds;
            localStorage.setItem(StorageConstants.expiredAt, '' + expiresAt);
          }

          if (tokenResponse.refresh_token) {
            localStorage.setItem(StorageConstants.refreshToken, tokenResponse.refresh_token);
          }
        } else {
            console.error(ErrorMessagesConstants.invalidToken);
        }
    }

    /**
     * Gets the access_token from the local storage.
     *
     * @example getToken();
     *
     * @returns {access_token: string}
     */
    public getToken(): string {
        const token: string = localStorage.getItem(StorageConstants.accessToken);

        if (!token) {
            const message = String.Format(ErrorMessagesConstants.missingStoragekey, StorageConstants.accessToken);
            console.error(message);
        }

        return token;
    }
}
