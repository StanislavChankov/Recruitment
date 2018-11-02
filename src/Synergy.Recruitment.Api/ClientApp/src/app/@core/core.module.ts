import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { of as observableOf } from 'rxjs';
import { NbAuthModule, NbAuthJWTToken } from '@nebular/auth';
import { NbSecurityModule, NbRoleProvider } from '@nebular/security';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';

import { throwIfAlreadyLoaded } from './module-import-guard';
import { DataModule } from './data/data.module';
import { AnalyticsService } from './utils/analytics.service';
import { CandidateService, DateTimeService, ErrorService } from './services/index';
import { AuthService } from './auth/auth.service';
import { TokenStorage, UserStorage } from './storages';
import { TokenInterceptor } from './middlewares/token-interceptor';

const socialLinks = [
  {
    url: 'https://github.com/akveo/nebular',
    target: '_blank',
    icon: 'socicon-github',
  },
  {
    url: 'https://www.facebook.com/akveo/',
    target: '_blank',
    icon: 'socicon-facebook',
  },
  {
    url: 'https://twitter.com/akveo_inc',
    target: '_blank',
    icon: 'socicon-twitter',
  },
];

export  function getToken() {
  return localStorage.getItem('access_token_key');
}

export class NbSimpleRoleProvider extends NbRoleProvider {
  getRole() {
    // here you could provide any role based on any auth flow
    return observableOf('guest');
  }
}

export const NB_CORE_PROVIDERS = [
  ...DataModule.forRoot().providers,
  ...JwtModule.forRoot({
    config: {
      tokenGetter: getToken,
    },
  }).providers,
  ...NbAuthModule.forRoot({
      forms: {
        login: {
          strategy: 'email',
          socialLinks: socialLinks,
        },
        register: {
          socialLinks: socialLinks,
        },
      },
    strategies: [
      [AuthService,
        {
          name: 'email',
          token:
          {
            class: NbAuthJWTToken,  // <----
          },
        }],
      // NbPasswordAuthStrategy.setup({
      //   name: 'email',
      //   baseEndpoint: 'http://localhost:4400/api/auth/',
      //   logout: {
      //     redirect: {
      //       success: '/auth/login',
      //       failure: '/auth/login',
      //     },
      //   },
      //   requestPass: {
      //     redirect: {
      //       success: '/auth/reset-password',
      //     },
      //   },
      //   resetPass: {
      //     redirect: {
      //       success: '/auth/login',
      //     },
      //   },
      //   errors: {
      //     key: 'data.errors',
      //   },
      // }),
    ],
  }).providers,
  NbSecurityModule.forRoot({
    accessControl: {
      guest: {
        view: '*',
      },
      user: {
        parent: 'guest',
        create: '*',
        edit: '*',
        remove: '*',
      },
    },
  }).providers,
  { provide: NbRoleProvider, useClass: NbSimpleRoleProvider },
  AnalyticsService,
];

export const businessServices = [
  ErrorService,
  DateTimeService,
  AuthService,
];

export const storages = [
  TokenStorage,
  UserStorage,
];

export const restServices = [
  CandidateService,
];

export const externalServices = [
  JwtHelperService,
];

@NgModule({
  imports: [
    CommonModule,
    HttpModule,
    JwtModule.forRoot({}),
  ],
  exports: [
    NbAuthModule,
  ],
  declarations: [],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }

  static forRoot(): ModuleWithProviders {
    return <ModuleWithProviders>{
      ngModule: CoreModule,
      providers: [
        ...NB_CORE_PROVIDERS,
        ...restServices,
        ...businessServices,
        ...externalServices,
        ...storages,
        {
          provide: HTTP_INTERCEPTORS,
          useClass: TokenInterceptor,
          multi: true,
        },
        // TODO: FIX it to work with abstract providers.
        // { provide: ErrorBaseService, useClass: ErrorService },
        // { provide: CandidateBaseService, useClass: CandidateService },
      ],
    };
  }
}
