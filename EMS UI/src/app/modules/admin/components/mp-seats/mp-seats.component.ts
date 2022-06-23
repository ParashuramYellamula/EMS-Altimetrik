import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConstituencyService } from 'src/app/services/constituency.service';

export interface ConstituencyDetails {
  id: string,
  constituencyName: string,
  state: string,
  currentMember: string
}
@Component({
  selector: 'app-mp-seats',
  templateUrl: './mp-seats.component.html',
  styleUrls: ['./mp-seats.component.css']
})
export class MpSeatsComponent implements OnInit {
 
  displayedColumns : Array<string>= ['ConstituencyName', 'State', 'Current Member' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<ConstituencyDetails> = [];
  states: Array<string> = [];

  constructor(private modalService: NgbModal,private constituencyService:ConstituencyService) { }

  ngOnInit() : void {
    this.getConstituencys();
  }
  getConstituencys() {
    this.constituencyService.getConstituencys().subscribe(res => {
      const data:any = res;
      this.dataSource = data;
      this.states = data.map(function(a) {return a.state;});
      this.states= this.states.filter((item, i, ar) => ar.indexOf(item) === i);
    },err => {
      console.log("err",err);
    })
  }
  
  removeConstituency(constituencyName){
    let constituencyObject = {};
    constituencyObject['constituencyName'] = constituencyName;
   this.constituencyService.removeConstituency(constituencyObject).subscribe(res => {
    this.getConstituencys();
   },err => {
     console.log("Err",err);
   })
  }

  openModal(add:NgbModal) {
    this.modalRef = this.modalService.open(add, { centered: true, size: 'md', backdrop: 'static', keyboard : false });
  }

  search() {
    //console.log(this.searchName);
  }

  addedConstituency() {
    this.getConstituencys();
    this.modalRef.close();
  }

  closeModal() {
    this.modalRef.close();
  }

}
