import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { VotersService } from 'src/app/services/voters.service';
export interface UserDetails {
  id: string,
  firstName: string,
  lastName: string,
  aadhar: string,
  mobile: string,
  email: string,
  address: string,
  dateOfBirth: string,
}
@Component({
  selector: 'app-voter-details',
  templateUrl: './voter-details.component.html',
  styleUrls: ['./voter-details.component.css']
})
export class VoterDetailsComponent implements OnInit {

  displayedColumns : Array<string>= ['First Name', 'Last Name', 'Aadhar','Mobile Number','Email','Address','DateOfBirth' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<UserDetails> = [];

  constructor(private modalService: NgbModal,private voterService:VotersService) { }

  ngOnInit(): void {
    this.getVoters();
  }

  getVoters() {
    this.voterService.getVoters().subscribe(res => {
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

  addedVoter() {
    this.getVoters();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }

}
