import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VotersService } from 'src/app/services/voters.service';

@Component({
  selector: 'app-add-voter',
  templateUrl: './add-voter.component.html',
  styleUrls: ['./add-voter.component.css']
})
export class AddVoterComponent implements OnInit {

  @Output() addVoter = new EventEmitter();
  @Output() close = new EventEmitter();

  addVoterForm: FormGroup;
  
  constructor(private fb: FormBuilder,private votersServce:VotersService) { }

  ngOnInit(): void {
    this.initialiseForm();
  }

  initialiseForm() {
    this.addVoterForm = this.fb.group({
      firstName:  ['', [Validators.required]],
      lastNameName:['',[Validators.required]],
      aadhar:['',[Validators.required]],
      email:['',[Validators.required]],
      mobile:['',[Validators.required]],
      address:['',[Validators.required]],
      dateOfBirth:['',[Validators.required]]
    });
  }

  addVoterDetails(voterDetails){
    let voterObject = {};
    voterObject['firstName'] = voterDetails.value.firstName;
    voterObject['lastNameName'] = voterDetails.value.lastNameName;
    voterObject['aadhar'] = voterDetails.value.aadhar;
    voterObject['email'] = voterDetails.value.email;
    voterObject['mobile'] = voterDetails.value.mobile;
    voterObject['address'] = voterDetails.value.address;
    voterObject['dateOfBirth'] = voterDetails.value.dateOfBirth;
   this.votersServce.addVoter(voterObject).subscribe(res => {
      //console.log("res",res);
      this.addVoter.emit();
   },err => {
     console.log("Err",err);
   })
    // this.addVoter.emit();
  }

  cancel() {
    this.close.emit();
  }

}
