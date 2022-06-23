import { ResultComponent } from './components/result/result.component';
import { CastVoteComponent } from './components/cast-vote/cast-vote.component';
import { VoteComponent } from './components/vote/vote.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoterRoutingModule } from './voter-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VoterDetailsComponent } from './components/voter-details/voter-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddVoterComponent } from './components/add-voter/add-voter.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';


@NgModule({
  declarations: [
    DashboardComponent,
    VoterDetailsComponent,
    AddVoterComponent,
    VoteComponent,
    CastVoteComponent,
    ResultComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    VoterRoutingModule
  ]
})
export class VoterModule { }
