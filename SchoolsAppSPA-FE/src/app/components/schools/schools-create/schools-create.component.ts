import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-schools-create',
  templateUrl: './schools-create.component.html',
  styleUrls: ['./schools-create.component.scss']
})
export class SchoolsCreateComponent implements OnInit {
  @Output() schoolCreateEvent = new EventEmitter<string>();
  public schoolName: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  public createSchool(){
    this.schoolCreateEvent.emit(this.schoolName);
  }
}


