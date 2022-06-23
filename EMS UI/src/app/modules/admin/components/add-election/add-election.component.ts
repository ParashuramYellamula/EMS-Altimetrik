import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ElectionService } from 'src/app/services/election.service';

@Component({
  selector: 'app-add-election',
  templateUrl: './add-election.component.html',
  styleUrls: ['./add-election.component.css']
})
export class AddElectionComponent implements OnInit {

  
  @Output() addElection = new EventEmitter();
  @Output() close = new EventEmitter();

  addElectionForm: FormGroup;
  
  constructor(private fb: FormBuilder,private electionService:ElectionService) { }

  ngOnInit() : void {
    this.initialiseForm();
  }
  initialiseForm() {
    this.addElectionForm = this.fb.group({
      candidate:  ['', [Validators.required]],
      party:['',[Validators.required]],
      constituency:['',[Validators.required]],
      symbol:['',[Validators.required]]
    });
  }

  addElectionDetails(electionDetails){
    let electionObject = {};
    electionObject['candidate'] = electionDetails.value.candidate;
    electionObject['party'] = electionDetails.value.party;
    electionObject['constituency'] = electionDetails.value.constituency;
    electionObject['symbol'] = electionDetails.value.symbol;
   this.electionService.registerElection(electionObject).subscribe(res => {
      this.addElection.emit();
   },err => {
     console.log("Err",err);
   })
  }

  cancel() {
    this.close.emit();
  }


}

