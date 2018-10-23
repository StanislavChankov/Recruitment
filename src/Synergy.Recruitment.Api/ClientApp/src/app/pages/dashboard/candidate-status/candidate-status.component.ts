import { Component, OnInit, Input, ElementRef } from '@angular/core';

import 'rxjs/add/observable/interval';
import { Observable } from 'rxjs/Rx';

import { CandidateStatus } from '../../../@shared/data-models/candidates/candidate-status';
import { CandidateStatusPresent } from '../../../@shared/present-models/candidates/candidate-status.present';
import { DateTimeService } from '../../../@core/business-services/date-time.service';
import { CandidateFactory } from '../../../@shared/factories/candidate-factory';

@Component({
  selector: 'dashboard-candidate-status',
  templateUrl: './candidate-status.component.html',
  styleUrls: ['./candidate-status.component.scss'],
})
export class CandidateStatusComponent implements OnInit {

  @Input()
  candidate: CandidateStatus;

  candidatePresent: CandidateStatusPresent;
  timer: Observable<number>;

  constructor(
    private dateTimeService: DateTimeService,
    private elRef: ElementRef) {}

  ngOnInit() {
    this.candidatePresent = CandidateFactory.getPresent(this.candidate);

    this.initTimerUpdate();
  }

  private getDraggingClass(): string {
    const parentElement: HTMLElement = this.elRef.nativeElement;
    const hasDragClass = parentElement.classList.contains('gu-transit');

    return hasDragClass ? 'gu-transit' : '';
  }

  private initTimerUpdate(): void {
    this.timer = Observable.timer(0, 1000);

    this.timer.subscribe(tick => {
      this.candidatePresent.updatedBefore =
      this.dateTimeService.getTimeBetweenDates(new Date(this.candidate.updatedOn), new Date());
    });
  }
}
