import { ElectionsComponent } from './components/elections/elections.component';
import { SymbolsComponent } from './components/symbols/symbols.component';
import { VoterDetailsComponent } from './components/voter-details/voter-details.component';
import { AdminComponent } from './admin.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { MpSeatsComponent } from './components/mp-seats/mp-seats.component';
import { CandidatesComponent } from './components/candidates/candidates.component';
import { PartyComponent } from './components/party/party.component';

const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    children: [
      {
        path:'admin',
        component:AdminComponent
      },
      {
        path: 'voter',
        component: VoterDetailsComponent
      },
      {
        path: 'mpseats',
        component: MpSeatsComponent
      },
      {
        path: 'party',
        component: PartyComponent
      },
      {
        path: 'candidate',
        component: CandidatesComponent
      },
      {
        path: 'symbols',
        component: SymbolsComponent
      },
      {
        path: 'elections',
        component: ElectionsComponent
      },
      {path: '', redirectTo: 'admin', pathMatch: 'full'}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
