import { Component, OnInit, } from '@angular/core';
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

  constructor(private schoolsService: SchoolsService) { }

  ngOnInit(): void {
    this.schoolsService.getAll().subscribe((schoolsData) => {
      this.schools = schoolsData;
    })
  }
  
  public removeSchool(removeSchoolEvent:any):void{
    let id = removeSchoolEvent;
    this.schoolsService.delete(id).subscribe((v) => console.info(v, {responseType: 'text'}));
    this.schools = this.schools.filter(s=>s.id != id);
    // istrinti ir studentus is front end, kurie tai school priklauso 
  }

  public createSchool(schoolEvent: any): void {
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
    
    console.log("Add Schools is called");
  }
}
