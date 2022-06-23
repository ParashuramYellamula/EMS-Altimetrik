import { VoteComponent } from './components/vote/vote.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VoterDetailsComponent } from './components/voter-details/voter-details.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      
      {
        path:'voters',
        component:VoterDetailsComponent
      },
      {
        path:'vote',
        component:VoteComponent
      },
      {path: '', redirectTo: 'voters', pathMatch: 'full'},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VoterRoutingModule { }
