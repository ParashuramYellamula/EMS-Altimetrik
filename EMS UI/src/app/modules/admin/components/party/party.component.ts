import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PartyService } from 'src/app/services/party.service';

export interface PartyDetails {
  id: string,
  name: string,
  description: string,
  address: string,
  symbol: string
}
@Component({
  selector: 'app-party',
  templateUrl: './party.component.html',
  styleUrls: ['./party.component.css']
})
export class PartyComponent implements OnInit {

  displayedColumns : Array<string>= ['Name', 'Description', 'Address','Symbol' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<PartyDetails> = [];

  constructor(private modalService: NgbModal,private partyService:PartyService) { }

  ngOnInit() : void {
    this.getPartys();
  }
  getPartys() {
    this.partyService.getPartys().subscribe(res => {
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

  addedParty() {
    this.getPartys();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }
}
