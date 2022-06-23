import { Component, OnInit } from '@angular/core';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SymbolService } from 'src/app/services/symbol.service';

export interface SymbolDetails {
  id: string,
  name: string,
  symbol: string
}

@Component({
  selector: 'app-symbols',
  templateUrl: './symbols.component.html',
  styleUrls: ['./symbols.component.css']
})
export class SymbolsComponent implements OnInit {

  displayedColumns : Array<string>= ['Name', 'Symbol' ];
  searchName:string;
  modalRef:NgbModalRef;
  dataSource: Array<SymbolDetails> = [];

  constructor(private modalService: NgbModal,private symbolService:SymbolService) { }

  ngOnInit() : void {
    this.getSymbols();
  }
  getSymbols() {
    this.symbolService.getSymbols().subscribe(res => {
      const data:any = res;
      this.dataSource = data;
    },err => {
      console.log("err",err);
    })
  }
  search() {
    //console.log(this.searchName);
  }

}
