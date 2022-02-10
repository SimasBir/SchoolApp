import { Component, OnInit } from '@angular/core';
import StudentCreate from 'src/app/Models/student-create.model';
import Student from 'src/app/Models/student.model';
import { StudentsService } from 'src/app/services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  public students: Student[] = [];
  constructor(private studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentsService.getAll().subscribe((studentsData) => {
      this.students = studentsData;
    })
  }

  public removeStudent(removeStudentEvent: any): void {
    let id = removeStudentEvent;
    this.studentsService.delete(id).subscribe((v) => console.info(v, { responseType: 'text' }));
    this.students = this.students.filter(s => s.id != id);
  }

  public createStudent(studentCreateEvent: any): void {

    let createStudent: StudentCreate = {
      name: studentCreateEvent.name,
      schoolId: studentCreateEvent.schoolId
    }
    this.studentsService.create(createStudent).subscribe((studentId) => {
      this.studentsService.getById(studentId).subscribe((student)=> {
        this.students.push(student);
      });
    });
    console.log("Add student is called");
  }
}
