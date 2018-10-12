import { Component, OnDestroy } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { takeWhile } from 'rxjs/operators/takeWhile' ;
import { DragulaService } from 'ng2-dragula';
import { Candidate } from '../../@shared/data-models/candidates/Candidate';

interface CardSettings {
  title: string;
  iconClass: string;
  type: string;
}

@Component({
  selector: 'ngx-dashboard',
  styleUrls: ['./dashboard.component.scss'],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnDestroy {

  private alive = true;

  lightCard: CardSettings = {
    title: 'Light',
    iconClass: 'nb-lightbulb',
    type: 'primary',
  };
  rollerShadesCard: CardSettings = {
    title: 'Roller Shades',
    iconClass: 'nb-roller-shades',
    type: 'success',
  };
  wirelessAudioCard: CardSettings = {
    title: 'Wireless Audio',
    iconClass: 'nb-audio',
    type: 'info',
  };
  coffeeMakerCard: CardSettings = {
    title: 'Coffee Maker',
    iconClass: 'nb-coffee-maker',
    type: 'warning',
  };

  statusCards: string;

  commonStatusCardsSet: CardSettings[] = [
    this.lightCard,
    this.rollerShadesCard,
    this.wirelessAudioCard,
    this.coffeeMakerCard,
  ];

  statusCardsByThemes: {
    default: CardSettings[];
    cosmic: CardSettings[];
    corporate: CardSettings[];
  } = {
    default: this.commonStatusCardsSet,
    cosmic: this.commonStatusCardsSet,
    corporate: [
      {
        ...this.lightCard,
        type: 'warning',
      },
      {
        ...this.rollerShadesCard,
        type: 'primary',
      },
      {
        ...this.wirelessAudioCard,
        type: 'danger',
      },
      {
        ...this.coffeeMakerCard,
        type: 'secondary',
      },
    ],
  };

  candidates: Array<Candidate> = [
    { firstName: 'Marcia', lastName: 'Cantu', position: '.NET'  } as Candidate,
    { firstName: 'Ryder', lastName: 'Nicholson', position: 'Java'  } as Candidate,
    { firstName: 'Eloisa', lastName: 'Wise', position: 'QA'  } as Candidate,
    { firstName: 'Johnathon', lastName: 'Fountain', position: '.NET'  } as Candidate,
  ];

  candidates1: Array<Candidate> = [
    { firstName: 'Lyra', lastName: 'Thomas', position: 'BA'  } as Candidate,
    { firstName: 'Lacy', lastName: 'Reilly', position: 'DBA'  } as Candidate,
    { firstName: 'Tiya', lastName: 'Atkins', position: 'BI'  } as Candidate,
  ];

  candidates2: Array<Candidate> = [
    { firstName: 'Harris', lastName: 'Weir', position: 'Finance'  } as Candidate,
    { firstName: 'Cassia', lastName: 'Livingston', position: 'Accountant'  } as Candidate,
    { firstName: 'Tehya', lastName: 'Brooks', position: 'Consultant'  } as Candidate,
  ];

  candidates3: Array<Candidate> = [
    { firstName: 'Herbie', lastName: 'Major', position: '.NET'  } as Candidate,
    { firstName: 'Morwenna', lastName: 'Mcdonald', position: 'BA'  } as Candidate,
    { firstName: 'Mariyah', lastName: 'Guerrero', position: 'DBA'  } as Candidate,
    { firstName: 'Caden', lastName: 'Turnbull', position: 'Accountant'  } as Candidate,
  ];

  candidates4: Array<Candidate> = [
    { firstName: 'Fearne', lastName: 'Cox', position: '.NET'  } as Candidate,
    { firstName: 'Zoey', lastName: 'Ashley', position: 'Finance'  } as Candidate,
    { firstName: 'Luqman', lastName: 'Davila', position: 'Lead'  } as Candidate,
  ];

  constructor(
    private themeService: NbThemeService,
    private dragulaService: DragulaService) {

      this.dragulaService.createGroup('Candidates', {
        // ...
      });

      this.dragulaService.dropModel('Candidates').subscribe(args => {
        // console.log(args);
      });

    this.themeService.getJsTheme()
      .pipe(takeWhile(() => this.alive))
      .subscribe(theme => {
        this.statusCards = this.statusCardsByThemes[theme.name];
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
