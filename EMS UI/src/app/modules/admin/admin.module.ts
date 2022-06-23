import { AddElectionComponent } from './components/add-election/add-election.component';
import { ElectionsComponent } from './components/elections/elections.component';
import { AddCandidateComponent } from './components/add-candidate/add-candidate.component';
import { AddConstituencyComponent } from './components/add-constituency/add-constituency.component';
import { SymbolsComponent } from './components/symbols/symbols.component';
import { VoterDetailsComponent } from './components/voter-details/voter-details.component';
import { AddPartyComponent } from './components/add-party/add-party.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MpSeatsComponent } from './components/mp-seats/mp-seats.component';
import { PartyComponent } from './components/party/party.component';
import { CandidatesComponent } from './components/candidates/candidates.component';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';



@NgModule({
  declarations: [
    AdminDashboardComponent,
    MpSeatsComponent,
    PartyComponent,
    CandidatesComponent,
    AddPartyComponent,
    VoterDetailsComponent,
    SymbolsComponent,
    AddConstituencyComponent,
    AddCandidateComponent,
    ElectionsComponent,
    AddElectionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }


