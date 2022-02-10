import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import SchoolCreate from '../Models/school-create.model';
import School from '../Models/school.model';

@Injectable({
  providedIn: 'root'
})
export class SchoolsService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<School[]>{
    return this.httpClient.get<School[]>('https://localhost:44365/school');
  }
  public delete(id:number):Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44365/school/${id}`);
  } 
  public create(schoolCreate: SchoolCreate) : Observable<number> {
    return this.httpClient.post<number>(`https://localhost:44365/school`, schoolCreate);
  }

  //https://localhost:44365/school

}
