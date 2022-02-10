import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import StudentCreate from '../Models/student-create.model';
import Student from '../Models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Student[]>{
    return this.httpClient.get<Student[]>('https://localhost:44365/student');
  }
  public delete(id:number):Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44365/student/${id}`);
  } 
  public create(studentCreate: StudentCreate) : Observable<number> {
    return this.httpClient.post<number>(`https://localhost:44365/student`, studentCreate);
  }
  public getById(id: number): Observable<Student>{
    return this.httpClient.get<Student>(`https://localhost:44365/student/${id}`);
  }

    //https://localhost:44365/student
}
