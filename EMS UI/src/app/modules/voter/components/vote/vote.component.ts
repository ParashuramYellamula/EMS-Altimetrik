import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StringifyOptions } from 'querystring';
import { ElectionService } from 'src/app/services/election.service';


export interface ElectionDetails {
  id: string,
  candidate: string,
  constituency: string,
  party: string,
  symbol: string
}

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {

  displayedColumns : Array<string>= ['Constituency' ];
  
  displayedColumns1 : Array<string>= ['Constituency', 'Candidate', 'Party','Symbol' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<ElectionDetails> = [];
  public constituency: string;
  constructor(private modalService: NgbModal,private electionService:ElectionService) { }

  ngOnInit() : void {
    this.getElections();
  }


  getElections() {
    this.electionService.getCurrentElections().subscribe(res => {
      const data:any = res;
      this.dataSource = data;
    },err => {
      console.log("err",err);
    })
  }
  
  openModal(add:NgbModal,constituencyName:string) {
    this.electionService.constituency=constituencyName;
    this.constituency=constituencyName;
    this.modalRef = this.modalService.open(add, { centered: true, size: 'lg', backdrop: 'static', keyboard : false });
  }
  openResult(res:NgbModal,constituencyName:string) {
      this.electionService.constituency=constituencyName;
      this.constituency=constituencyName;
      this.modalRef = this.modalService.open(res, { centered: true, size: 'lg', backdrop: 'static', keyboard : false });
    }
  search() {
    //console.log(this.searchName);
  }

  addedElections() {
    this.getElections();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }

}
