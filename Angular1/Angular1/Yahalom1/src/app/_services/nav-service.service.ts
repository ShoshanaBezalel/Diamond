import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavServiceService {
 
  baseUrl = 'https://localhost:44369';
  constructor(private http: HttpClient) { }
  private updateNavSubject = new Subject<void>();

  updateNav$ = this.updateNavSubject.asObservable();

  updateNav(): void {
    this.updateNavSubject.next();
  }
  getDateOfWedding(id:number){
    const url=`${this.baseUrl}/api/Customer/getDateOfWedding?idCustomer=${id}`
    return this.http.get<any>(url);
  }
}
