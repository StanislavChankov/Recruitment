import { Component, Inject } from '@angular/core';

import { NB_AUTH_OPTIONS, NbAuthStrategy, NbAuthResult } from '@nebular/auth';
import { getDeepFromObject } from '@nebular/auth/helpers';
import { AuthService } from '../auth.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  showMessages: any = {};
  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};
  register: Function;
  validation: any;

  constructor(
    @Inject(NB_AUTH_OPTIONS) private authOptions,
    private authService: AuthService,
    private router: Router) {
      this.register = authOptions.strategies[0][0].prototype.register;
      this.showMessages = this.authOptions.forms.register.showMessages;
      this.validation = this.authOptions.forms.validation;
  }

  public registerHandler(): void {
    this.errors = this.messages = [];
    this.submitted = true;

    this.authService
        .register(this.user)
        .flatMap(() => this.authService.authenticate(this.user))
        .subscribe((loginResult: NbAuthResult) => {
          const redirect = loginResult.getRedirect();
          if (redirect) {
            return this.router.navigateByUrl(redirect);
          }
        });
  }

  public getConfigValue(key: string): any {
    return getDeepFromObject(this.authOptions, key, null);
  }
}
