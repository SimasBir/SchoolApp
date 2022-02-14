import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import Student from 'src/app/Models/student.model';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {
  @Input() studentsInput: Student[] = [];
  @Output() removeStudentEvent = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }
  public removeStudent(studentId: number) {
    this.removeStudentEvent.emit(studentId);
  }
}