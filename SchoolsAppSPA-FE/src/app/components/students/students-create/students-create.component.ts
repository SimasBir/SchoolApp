import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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
  
  public studentName: string = '';
  public schoolId: number = 0;
  public schools: School[] = [];

  constructor(private schoolsService: SchoolsService) { }

  ngOnInit(): void {
    this.schoolsService.getAll().subscribe((schoolsData) => {
      this.schools = schoolsData;
    })
  }

  public createStudent() {
    let createStudent: StudentCreate = {
      name: this.studentName,
      schoolId: this.schoolId
    };
    this.studentCreateEvent.emit(createStudent);
  }
}
