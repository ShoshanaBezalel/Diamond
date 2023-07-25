import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SupplierDTO } from './SupplierDTO';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  private baseUrl = 'https://localhost:44369'; // Replace with the actual API URL

  constructor(private http: HttpClient) { }

  // sortSupplier(category: any): Observable<SupplierDTO[]> {
  //   const url = `${this.apiUrl}/sortSupplier?categoryId=${categoryId}`; // Adjust the URL based on your API endpoint
  //   return this.http.get<SupplierDTO[]>(url);
  // }
  // sortSupplier(categoryId: number, placeId: number, priceFrom: number, priceUntil: number): Observable<any> {
  //   const url = `${this.baseUrl}/api/Supplier/sortSupplier?Id_Categoty=${categoryId}&Place_Id=${placeId}&Price_from=${priceFrom}&Price_Until=${priceUntil}`;
  //   return this.http.get<any>(url);
  // }
  // sortSupplier(category: number, location: number, priceFrom: number, priceUntil: number): Observable<any> {
  //   const url = `${this.baseUrl}/api/Supplier/sortSupplier`;
  //   const params = {
  //     Id_Categoty: category,
  //     Place_Id: location,
  //     Price_from: priceFrom,
  //     Price_Until: priceUntil
  //   };

  //   return this.http.get<any>(url, { params: params });
  // }
  
  getSupplierCategory():Observable<any>{
    const url = `${this.baseUrl}/api/Supplier/getSupplierCategory`;
    return this.http.get<any>(url);
  }
  getSecondCtegory(id:number):Observable<any>{
    const url = `${this.baseUrl}/api/Supplier/getSecondCtegory?Id_Categoty=${id}`;
    return this.http.get<any>(url);
  }
  sortSupplier(categoryId: number, placeId: number, priceFrom: number, priceUntil: number): Observable<any> {
    console.log(categoryId,placeId,priceFrom,priceUntil ,'אני בסרויס')
    const url = `https://localhost:44369/api/Supplier/sortSupplier?Id_Categoty=${categoryId}&Place_Id=${placeId}&Price_from=${priceFrom}&Price_Until=${priceUntil}`;

  
     return this.http.get<any>(url);
  
}
  
}
