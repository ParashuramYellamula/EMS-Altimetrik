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
  selector: 'app-elections',
  templateUrl: './elections.component.html',
  styleUrls: ['./elections.component.css']
})
export class ElectionsComponent implements OnInit {

  displayedColumns : Array<string>= ['Constituency', 'Candidate', 'Party','Symbol' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<ElectionDetails> = [];

  constructor(private modalService: NgbModal,private electionService:ElectionService) { }

  ngOnInit() : void {
    this.getElections();
  }


  getElections() {
    this.electionService.getElections().subscribe(res => {
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

  addedElections() {
    this.getElections();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }

}
