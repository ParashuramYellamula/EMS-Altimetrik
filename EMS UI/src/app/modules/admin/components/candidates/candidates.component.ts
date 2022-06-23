import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StringifyOptions } from 'querystring';
import { CandidateService } from 'src/app/services/candidate.service';


export interface CandidateDetails {
  id: string,
  name: string,
  constituency: string,
  party: string,
  address: string
}

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {

  displayedColumns : Array<string>= ['Name', 'Party', 'Constituency','Address' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<CandidateDetails> = [];

  constructor(private modalService: NgbModal,private candidateService:CandidateService) { }

  ngOnInit() : void {
    this.getCandidates();
  }


  getCandidates() {
    this.candidateService.getCandidates().subscribe(res => {
      const data:any = res;
      this.dataSource = data;
    },err => {
      console.log("err",err);
    })
  }
  
  openModal(add:NgbModal) {
    this.modalRef = this.modalService.open(add, { centered: true, size: 'md', backdrop: 'static', keyboard : false });
  }

  search() {
    //console.log(this.searchName);
  }

  addedCandidates() {
    this.getCandidates();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }

}
