import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NavServiceService } from './nav-service.service';
import { SupplierService } from './supplier.service';
import { BehaviorSubject, Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  url: string | undefined;
  private currentUserSource = new BehaviorSubject<any | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient, private navService:NavServiceService,private supplierService:SupplierService) { }
  baseUrl = 'https://localhost:44369';
  
  updateNavComponent(): void {
    this.navService.updateNav();
  }
  setCurrentUser(user: any) {
    this.currentUserSource.next(user);
  }

  updateProfileCustomer(
    user:any): Observable<any> {
      console.log('אני מנס ה לראות אם הוא ',user)
    const { firstName, lastName, password, phone, email, dateOfWedding, isGroom} = user;
     const url = `${this.baseUrl}/api/Customer/EditCustomer?FirstName=${firstName}&LastName=${lastName}&Password=${password}&Phone=${phone}&Email=${email}&DateOfWedding=${dateOfWedding}&IsGroom=${isGroom}`;
   return this.http.post<any>(url,{}).pipe(
      map(data => {
        if (!data.isError) {
          console.log('אני בסרויס',data)
          localStorage.setItem('user', JSON.stringify(user));
          localStorage.setItem('id_user',data.data);
         
           this.updateNavComponent(); 
           this.currentUserSource.next({});}
        })
    )
  }

  UpdateSupplier(user: any): Observable<any> {
    const { firstName, lastName, password, phone, email, businessName, idCategory,idSecondSupplierCategory, priceFrom, priceUntil, aboutMe, placeId } = user;
    const url = `${this.baseUrl}/api/Supplier/UpdateSupplier?FirstName=${firstName}&LastName=${lastName}&Password=${password}&Phone=${phone}&Email=${email}&BusinessName=${businessName}&IdCategory=${idCategory}&IdSecondSupplierCategory=${idSecondSupplierCategory}&PriceFrom=${priceFrom}&PriceUntill=${priceUntil}&AboutMe=${aboutMe}&PlaceId=${placeId}`;
    return this.http.put<any>(url, {}).pipe(
      map(data => {
        if (!data.isError) {
          console.log('אני בסרויס',data)
          localStorage.setItem('user', JSON.stringify(user));
          localStorage.setItem('id_user',data.data);
         
           this.updateNavComponent(); 
           this.currentUserSource.next(user);
           
         
        }
        else console.log
        
      }))
  }
  getSupplierCategory():Observable<any>{
   return this.supplierService.getSupplierCategory()
  }
  getSecondCtegory():Observable<any>{
    return this.supplierService.getSecondCtegory(1)
  }
 
}
