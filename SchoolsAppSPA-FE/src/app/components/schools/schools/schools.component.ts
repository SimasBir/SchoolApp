import { Component, EventEmitter, OnInit, Output, } from '@angular/core';
import SchoolCreate from 'src/app/Models/school-create.model';
import School from 'src/app/Models/school.model';
import { SchoolsService } from 'src/app/services/schools.service';

@Component({
  selector: 'app-schools',
  templateUrl: './schools.component.html',
  styleUrls: ['./schools.component.scss']
})
export class SchoolsComponent implements OnInit {
  public schools: School[] = [];
  @Output() childToParent = new EventEmitter<School[]>();
  @Output() schoolId = new EventEmitter<number>();

  constructor(private schoolsService: SchoolsService) { }

  ngOnInit(): void {
    this.schoolsService.getAll().subscribe((schoolsData) => {
      this.schools = schoolsData;
      this.childToParent.emit(this.schools);
    })
  }

  public removeSchool(removeSchoolEvent: any): void {
    let id = removeSchoolEvent;
    this.schoolsService.delete(id).subscribe()
    // ((v) => console.info(v, { responseType: 'text' }));
    this.schools = this.schools.filter(s => s.id != id);
    this.childToParent.emit(this.schools);
    this.schoolId.emit(id);
  }

  public createSchool(schoolEvent: any): void {
    if (schoolEvent.length > 2) {
      let createSchool: SchoolCreate = {
        name: schoolEvent
      }
      this.schoolsService.create(createSchool).subscribe((schoolId) => {
        let school: School = {
          id: schoolId,
          name: createSchool.name
        }
        this.schools.push(school);
      });
      this.childToParent.emit(this.schools);
      console.log("Add Schools is called");
    }
    else {
      console.warn("Name should be at least 3 symbols");
    }
  }

  public updateSchool(schoolEvent: any): void {
    if (schoolEvent.name.length > 2) {
      let createSchool: SchoolCreate = {
        name: schoolEvent.name
      }
      let id=schoolEvent.Id;
      this.schoolsService.update(id, createSchool).subscribe((schoolId) => {
        let school: School = {
          id: schoolId,
          name: createSchool.name
        }
        this.schools.push(school);
      });
      this.childToParent.emit(this.schools);
      console.log("Add Schools is called");
    }
    else {
      console.warn("Name should be at least 3 symbols");
    }
  }
}
