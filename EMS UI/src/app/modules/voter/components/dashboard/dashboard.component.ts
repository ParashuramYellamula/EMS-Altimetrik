import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  modalRef:NgbModalRef;
  constructor(private modalService:NgbModal, private route:Router) { }

  ngOnInit(): void {
  }

  openLogoutModal(logout:NgbModal) {
    this.modalRef = this.modalService.open(logout, { centered: true, size: 'md', backdrop: 'static', keyboard : false });
  }

  cancel() {
    this.modalRef.close();
  }

  userLogout() {
    this.modalRef.close();
    this.route.navigate(['/']);
  }

}
