import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import School from 'src/app/Models/school.model';

@Component({
  selector: 'app-schools-list',
  templateUrl: './schools-list.component.html',
  styleUrls: ['./schools-list.component.scss']
})
export class SchoolsListComponent implements OnInit {
  @Input() schoolsInput: School[] = [];
  @Output() removeSchoolEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }
  public removeSchool(schoolId:number){
    this.removeSchoolEvent.emit(schoolId);
  }
}
