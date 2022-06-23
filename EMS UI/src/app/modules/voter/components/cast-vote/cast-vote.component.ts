import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ElectionService } from 'src/app/services/election.service';


export interface ElectionDetails {
  id: string,
  candidate: string,
  constituency: string,
  party: string,
  symbol: string
}
@Component({
  selector: 'app-cast-vote',
  templateUrl: './cast-vote.component.html',
  styleUrls: ['./cast-vote.component.css']
})
export class CastVoteComponent implements OnInit {

  @Output() castVote = new EventEmitter();
  @Output() close = new EventEmitter();

  radioSelected:string;
  castVoteForm: FormGroup;
  displayedColumns : Array<string>= ['Candidate', 'Party','Symbol' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<ElectionDetails> = [];
  @Input() constituency: string = this.electionService.constituency;
  constructor(private fb: FormBuilder,private electionService:ElectionService) { }

  ngOnInit(): void {
    this.initialiseForm();
  }

  initialiseForm() {
    this.getElections(this.constituency);
  }
  getElections(constituency : string) {
    this.electionService.getElections().subscribe(res => {
      const data:any = res;
      this.dataSource = data.filter(x=> x.constituency == constituency);
    },err => {
      console.log("err",err);
    })
  }

  castVoteDetails(voteDetails){
    let voteObject = {};
    voteObject['constituency'] = voteDetails.constituency;
    voteObject['candidate'] = voteDetails.candidate;
   this.electionService.registerVote(voteObject).subscribe(res => {
      //console.log("res",res);
      this.castVote.emit();
      this.close.emit();
   },err => {
     console.log("Err",err);
   })
    // this.castVote.emit();
  }

  cancel() {
    this.close.emit();
  }

}
