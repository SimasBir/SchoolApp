import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import School from 'src/app/Models/school.model';

@Component({
  selector: 'app-schools-update',
  templateUrl: './schools-update.component.html',
  styleUrls: ['./schools-update.component.scss']
})
export class SchoolsUpdateComponent implements OnInit {
  @Input() my_modal_title?: string; //nebutinas
  @Input() my_modal_schoolId: number = 0;
  public schoolName: string = "";
  public school?: School;


  @Output() schoolUpdateEvent = new EventEmitter<any>();
  
  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  passBack() {
    let school: School = {
      id: this.my_modal_schoolId,
      name: this.schoolName,      
    }
    this.activeModal.close(school);
  }  
}
