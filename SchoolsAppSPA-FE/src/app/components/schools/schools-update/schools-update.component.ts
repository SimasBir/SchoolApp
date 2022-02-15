import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import School from 'src/app/Models/school.model';

@Component({
  selector: 'app-schools-update',
  templateUrl: './schools-update.component.html',
  styleUrls: ['./schools-update.component.scss']
})
export class SchoolsUpdateComponent implements OnInit {
  @Input() my_modal_title: string = "";
  @Input() my_modal_schoolId: number = 0;
  public schoolName: string = '';

  @Output() schoolUpdateEvent = new EventEmitter<any>();
  
  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }
  public updateSchool(){
    let updateSchool: School = {
      id: this.my_modal_schoolId,
      name: this.schoolName
    }
    this.schoolUpdateEvent.emit(updateSchool);
  }
}
