import { Component, Input } from '@angular/core';
import School from './Models/school.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SchoolsAppSPA-FE';
  public schools: School[]=[]; 
  public schoolId: number | null | undefined;

  public listSchool(childToParent:any){
    this.schools = childToParent;
  }
  public deleteSchool(schoolId:any){
    this.schoolId = schoolId
  }

}
