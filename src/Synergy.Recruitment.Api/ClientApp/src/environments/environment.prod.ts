/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
export const environment = {
  production: true,
  baseUrl: 'http://amazing94-001-site1.gtempurl.com',
};

export const apiUrls = {
  technology: {
    getAll: environment.baseUrl + '/api/technology',
  },
  candidate: {
    getAll: environment.baseUrl + '/api/candidate',
  },
  identity: {
    token: environment.baseUrl + '/connect/token',
    userInfo: environment.baseUrl + '/connect/userinfo',
    register: environment.baseUrl + '/api/account/register',
    actions: environment.baseUrl + '/api/users/{0}/action',
  },
};
