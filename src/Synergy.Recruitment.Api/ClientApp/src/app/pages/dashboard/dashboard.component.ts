import { Component, OnDestroy, OnInit } from '@angular/core';

import { takeWhile } from 'rxjs/operators/takeWhile' ;

import { DragulaService } from 'ng2-dragula';
import { NbThemeService } from '@nebular/theme';

import { CandidateStatus } from '../../@shared/data-models/candidates/candidate-status';
import { CandidateService } from '../../@core/services';

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
export class DashboardComponent implements OnDestroy, OnInit {

  //#region

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

  //#endregion
  candidatedCandidates: Array<CandidateStatus>;
  approvedForInterviewCandidates: Array<CandidateStatus>;
  interviewScheduledCandidates: Array<CandidateStatus>;
  taskAssignedCandidates: Array<CandidateStatus>;
  approvedCandidates: Array<CandidateStatus>;

  constructor(
    private themeService: NbThemeService,
    private dragulaService: DragulaService,
    private candidateService: CandidateService) {
      this.createDragulaGroup();
      this.themeService.getJsTheme()
        .pipe(takeWhile(() => this.alive))
        .subscribe(theme => {
          this.statusCards = this.statusCardsByThemes[theme.name];
      });
  }

  ngOnDestroy() {
    this.alive = false;
  }

  private createDragulaGroup(): void {
    const candidateGroup = this.dragulaService.find('Candidates');
    if (!candidateGroup) {
      this.dragulaService.createGroup('Candidates', {
        // ...
      });

      this.dragulaService.dropModel('Candidates').subscribe(args => {
        // console.log(args);
      });
    }
  }

  ngOnInit(): void {
    this.candidateService
      .getCandidatesStatus()
      .subscribe(candidates => {
        this.candidatedCandidates = candidates.filter(c => c.id < 4);
        this.approvedForInterviewCandidates = candidates.filter(c => c.id >= 4 && c.id < 8);
        this.interviewScheduledCandidates = candidates.filter(c => c.id >= 8 && c.id < 12);
        this.taskAssignedCandidates = candidates.filter(c => c.id >= 12 && c.id < 15);
        this.approvedCandidates = candidates.filter(c => c.id >= 15 && c.id < 18);
      });
  }
}
