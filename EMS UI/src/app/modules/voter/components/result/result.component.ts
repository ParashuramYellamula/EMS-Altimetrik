import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ElectionService } from 'src/app/services/election.service';


export interface ElectionDetails {
  id: string,
  candidate: string,
  constituency: string,
  party: string,
  symbol: string,
  vote: number
}
@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  @Output() castVote = new EventEmitter();
  @Output() close = new EventEmitter();

  radioSelected:string;
  castVoteForm: FormGroup;
  displayedColumns : Array<string>= ['Candidate', 'Party','Symbol', '#Votes' ];
  searchName:string;
  modalRef:NgbModalRef;
  max = 0;
  candidate='';
  winner: Array<ElectionDetails> =[];
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

      data.filter(x=> x.constituency == constituency).forEach(ele => {
    if (ele.votes > this.max) {
     this.max = ele.votes;
     this.candidate= ele.candidate;
    }
   });
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
