import { Injectable } from '@angular/core';

import { String } from 'typescript-string-operations';

import { StorageConstants, ErrorMessagesConstants } from '../../@shared/constants';
import { UserInfo } from '../../@shared/data-models';


@Injectable()
export class UserStorage {
    public getUserActions(): number {
        const userActions: string = localStorage.getItem(StorageConstants.actionsKey);
        if (!userActions) {
            const message = String.Format(ErrorMessagesConstants.missingStoragekey, StorageConstants.actionsKey);
            throw new Error(message);
        } else {
            return Number(userActions);
        }
    }

    public setUserActions(actions: number): void {
        if (!actions) {
            const message = String.Format(ErrorMessagesConstants.argumentNullException, 'actions');
            throw new Error(message);
        } else {
            localStorage.setItem(StorageConstants.actionsKey, actions.toString());
        }
    }

    public setUserInfo(userInfo: UserInfo): void {
        if (!userInfo) {
            const message = String.Format(ErrorMessagesConstants.argumentNullException, 'userInfo');
            throw new Error(message);
        } else {
            localStorage.setItem(StorageConstants.userInfoKey, JSON.stringify(userInfo));
        }
    }

    public getUserInfo(): UserInfo {
        const userInfo: string = localStorage.getItem(StorageConstants.userInfoKey);
        if (!userInfo) {
            const message = String.Format(ErrorMessagesConstants.missingStoragekey, StorageConstants.userInfoKey);
            throw new Error(message);
        } else {
            return JSON.parse(userInfo);
        }
    }

    public clearAll(): void {
        localStorage.removeItem(StorageConstants.userInfoKey);
        localStorage.removeItem(StorageConstants.actionsKey);
    }
}
