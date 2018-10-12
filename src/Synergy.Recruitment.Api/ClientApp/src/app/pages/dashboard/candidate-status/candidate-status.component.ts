import { Component, OnInit, Input } from '@angular/core';
import { Candidate } from '../../../@shared/data-models/candidates/Candidate';

@Component({
  selector: 'ngx-candidate-status',
  templateUrl: './candidate-status.component.html',
  styleUrls: ['./candidate-status.component.scss'],
})
export class CandidateStatusComponent implements OnInit {

  @Input()
  candidate: Candidate;

  constructor() { }

  ngOnInit() {
  }

}
