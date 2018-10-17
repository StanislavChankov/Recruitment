/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
export const environment = {
  production: true,
  baseUrl: 'http://amazing94-001-site1.gtempurl.com/api',
};

export const apiUrls = {
  technology: {
    getAll: environment.baseUrl + '/technology',
  },
  candidate: {
    getAll: environment.baseUrl + '/candidate',
  },
};
