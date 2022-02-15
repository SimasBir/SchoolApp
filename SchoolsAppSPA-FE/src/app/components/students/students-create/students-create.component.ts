import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges, OnChanges } from '@angular/core';
import School from 'src/app/Models/school.model';
import StudentCreate from 'src/app/Models/student-create.model';
import { SchoolsService } from 'src/app/services/schools.service';

@Component({
  selector: 'app-students-create',
  templateUrl: './students-create.component.html',
  styleUrls: ['./students-create.component.scss']
})
export class StudentsCreateComponent implements OnInit {
  @Output() studentCreateEvent = new EventEmitter<any>();
  @Input() schoolsInput: School[] = [];

  public studentName: string = '';
  public studentSurname: string = '';
  public schoolId: number = 0;

  constructor(private schoolsService: SchoolsService) { }

  ngOnInit(): void {
 
  }
  // ngOnChanges(changes:SimpleChanges){
  //  console.log(changes);
  // }

  public createStudent() {
    let createStudent: StudentCreate = {
      name: this.studentName,
      surname: this.studentSurname,
      schoolId: this.schoolId
    };
    this.studentCreateEvent.emit(createStudent);
  }
}
