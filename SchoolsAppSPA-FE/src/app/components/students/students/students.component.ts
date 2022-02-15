import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import School from 'src/app/Models/school.model';
import StudentCreate from 'src/app/Models/student-create.model';
import Student from 'src/app/Models/student.model';
import { StudentsService } from 'src/app/services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit, OnChanges {
  public students: Student[] = [];
  @Input() listSchools: School[] = [];
  @Input() deleteSchoolId: number | null | undefined;;


  constructor(private studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentsService.getAll().subscribe((studentsData) => {
      this.students = studentsData;
    })
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (this.deleteSchoolId != undefined) {

    const schoolChanges = changes['deleteSchoolId'].currentValue;
      // console.log(schoolChanges)
      this.students = this.students.filter(s => s.schoolId != schoolChanges);
    }
  }

  public removeStudent(removeStudentEvent: any): void {
    let id = removeStudentEvent;
    this.studentsService.delete(id).subscribe()
    // ((v) => 
    // console.info(v, { responseType: 'text' }));
    this.students = this.students.filter(s => s.id != id);
  }

  public createStudent(studentCreateEvent: any): void {

    if (studentCreateEvent.name.length > 2) {
      let createStudent: StudentCreate = {
        name: studentCreateEvent.name,
        surname: studentCreateEvent.surname,
        schoolId: studentCreateEvent.schoolId
      }
      this.studentsService.create(createStudent).subscribe((studentId) => {
        this.studentsService.getById(studentId).subscribe((student) => {
          this.students.push(student);
        });
      });
      console.log("Add student is called");
    }
    else {
      console.warn("Name should be at least 3 symbols");
    }
  }
}
