import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import School from 'src/app/Models/school.model';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { SchoolsUpdateComponent } from '../schools-update/schools-update.component';

@Component({
  selector: 'app-schools-list',
  templateUrl: './schools-list.component.html',
  styleUrls: ['./schools-list.component.scss']
})
export class SchoolsListComponent implements OnInit {
  public isCollapsed = true; //hidden for now
  @Input() schoolsInput: School[] = [];
  @Output() removeSchoolEvent = new EventEmitter<number>();
  @Output() updateSchoolEvent = new EventEmitter<any>();
  public schoolId?: number;

   constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }
  public removeSchool(schoolId: number) {
    this.removeSchoolEvent.emit(schoolId);
  }
  public getId(schoolId: number) {
    this.schoolId = schoolId
  }

  open(id: number) {
    const modalRef = this.modalService.open(SchoolsUpdateComponent)
    modalRef.componentInstance.my_modal_title = 'Update school name';
    modalRef.componentInstance.my_modal_schoolId = this.schoolId;

    modalRef.result.then((result) => {
      if (result) {
        console.log(result)
        this.updateSchoolEvent.emit(result);
      }
    }
    );
  }
}
