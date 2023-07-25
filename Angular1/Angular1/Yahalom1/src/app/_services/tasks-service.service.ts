import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MyTasks } from '../_models/task';

@Injectable({
  providedIn: 'root'
})
export class TasksServiceService {
  baseUrl = 'https://localhost:44369';

  constructor(private http: HttpClient) { }

  getTasksCustomer(id: number): Observable<any> {
    const url = `${this.baseUrl}/api/MyTasks/getTasksCustomer?idCustomer=${id}`;
    return this.http.get<any>(url);
  }

  createTask(task: any): Observable<any> {
    const url = `${this.baseUrl}/api/MyTasks/CreateTask`;
    return this.http.post<any>(url, task);
  }
  
  editTask(task:any) {
    const url = `${this.baseUrl}/api/MyTasks/EditTask`;
    return this.http.post<any>(url, task);
  }
 
  deleteTask(task: any): Observable<any> {
    console.log(task);
    const url = `https://localhost:44369/api/MyTasks/DeleteTask`;
    return this.http.delete(url, { body: task });
  }
  

}
