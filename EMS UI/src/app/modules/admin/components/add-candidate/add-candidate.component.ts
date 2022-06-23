import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CandidateService } from 'src/app/services/candidate.service';

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.css']
})
export class AddCandidateComponent implements OnInit {

  
  @Output() addCandidate = new EventEmitter();
  @Output() close = new EventEmitter();

  addCandidateForm: FormGroup;
  
  constructor(private fb: FormBuilder,private candidateService:CandidateService) { }

  ngOnInit() : void {
    this.initialiseForm();
  }
  initialiseForm() {
    this.addCandidateForm = this.fb.group({
      name:  ['', [Validators.required]],
      party:['',[Validators.required]],
      constituency:['',[Validators.required]],
      address:['',[Validators.required]]
    });
  }

  addCandidateDetails(candidateDetails){
    let candidateObject = {};
    candidateObject['name'] = candidateDetails.value.name;
    candidateObject['party'] = candidateDetails.value.party;
    candidateObject['constituency'] = candidateDetails.value.constituency;
    candidateObject['address'] = candidateDetails.value.address;
   this.candidateService.registerCandidate(candidateObject).subscribe(res => {
      this.addCandidate.emit();
   },err => {
     console.log("Err",err);
   })
  }

  cancel() {
    this.close.emit();
  }


}

