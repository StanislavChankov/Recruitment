/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  baseUrl: 'http://localhost:5000',
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
    register: environment.baseUrl + '/account/register',
    actions: environment.baseUrl + '/api/users/{0}/action',
  },
};
