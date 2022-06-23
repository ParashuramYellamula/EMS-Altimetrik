import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PartyService } from 'src/app/services/party.service';
@Component({
  selector: 'app-add-party',
  templateUrl: './add-party.component.html',
  styleUrls: ['./add-party.component.css']
})
export class AddPartyComponent implements OnInit {

  @Output() addParty = new EventEmitter();
  @Output() close = new EventEmitter();

  addPartyForm: FormGroup;
  
  constructor(private fb: FormBuilder,private partyServce:PartyService) { }

  ngOnInit() : void {
    this.initialiseForm();
  }
  initialiseForm() {
    this.addPartyForm = this.fb.group({
      name:  ['', [Validators.required]],
      contactNumber:['',[Validators.required]]
    });
  }

  addPartyDetails(partyDetails){
    let partyObject = {};
    partyObject['name'] = partyDetails.value.name;
    partyObject['description'] = partyDetails.value.description;
    partyObject['address'] = partyDetails.value.address;
    partyObject['symbol'] = partyDetails.value.symbol;
   this.partyServce.addParty(partyObject).subscribe(res => {
      this.addParty.emit();
   },err => {
     console.log("Err",err);
   })
  }

  cancel() {
    this.close.emit();
  }

}

