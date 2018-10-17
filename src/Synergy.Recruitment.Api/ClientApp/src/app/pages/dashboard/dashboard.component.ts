import { Component, OnDestroy, OnInit } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { takeWhile } from 'rxjs/operators/takeWhile' ;
import { DragulaService } from 'ng2-dragula';
import { Candidate } from '../../@shared/data-models/candidates/Candidate';
import { CandidateService } from '../../@core/services/candidate.service';

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

  candidatedCandidates: Array<Candidate>;

  approvedForInterviewCandidates: Array<Candidate>;

  interviewScheduledCandidates: Array<Candidate>;

  taskAssignedCandidates: Array<Candidate>;
  approvedCandidates: Array<Candidate>;

  constructor(
    private themeService: NbThemeService,
    private dragulaService: DragulaService,
    private candidateService: CandidateService) {

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
