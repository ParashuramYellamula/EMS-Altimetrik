import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConstituencyService } from 'src/app/services/constituency.service';

@Component({
  selector: 'app-add-constituency',
  templateUrl: './add-constituency.component.html',
  styleUrls: ['./add-constituency.component.css']
})
export class AddConstituencyComponent implements OnInit {

  @Output() addConstituency = new EventEmitter();
  @Output() close = new EventEmitter();

  addConstituencyForm: FormGroup;
  
  constructor(private fb: FormBuilder,private constituencyService:ConstituencyService) { }

  ngOnInit() : void {
    this.initialiseForm();
  }

  
  initialiseForm() {
    this.addConstituencyForm = this.fb.group({
      constituencyName:  ['', [Validators.required]],
      state:['',[Validators.required]],
      currentMember:['',[Validators.required]]
    });
  }

  addConstituencyDetails(constituencyDetails){
    let constituencyObject = {};
    constituencyObject['constituencyName'] = constituencyDetails.value.constituencyName;
    constituencyObject['state'] = constituencyDetails.value.state;
    constituencyObject['currentMember'] = constituencyDetails.value.currentMember;
   this.constituencyService.addConstituency(constituencyObject).subscribe(res => {
      this.addConstituency.emit();
   },err => {
     console.log("Err",err);
   })
  }

  cancel() {
    this.close.emit();
  }


}

