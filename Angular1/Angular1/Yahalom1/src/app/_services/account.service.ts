import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../_models/user';
import { NavServiceService } from './nav-service.service';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = 'https://localhost:44369';
  req:any |any;
  private currentUserSource = new BehaviorSubject<any | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  url: string=''

  constructor(private http: HttpClient, private navService:NavServiceService) { }

  private loggedIn = new BehaviorSubject<boolean>(false);
  public loggedIn$ = this.loggedIn.asObservable();
  
  login(req :any) {
    
    const url = `${this.baseUrl}/api/Auth/Login/`
 
    return this.http.post(url, req)
  
      
  }



  registerS(model: any) {
    console.log('אני' ,model)
    return this.http.post<any>(this.baseUrl +'/api/Supplier/CreateSupplier', model).pipe(
      map(user => {
        if (!user.isError) {
          console.log('אני בסרויס',user)
          localStorage.setItem('user', JSON.stringify(model));
          localStorage.setItem('id_user',user.data);
          localStorage.setItem('supplier',"true");
          this.updateNavComponent(); 
          this.currentUserSource.next(user);
         
        }
        
      })
    )
  }

  registerCustomer(
    model:any
  ): Observable<any> {
    this.url = `${this.baseUrl}/api/Customer/CreateCustomer`
    const body = {
      FirstName: model.firstName,
      LastName: model.lastName,
      Password: model.password,
      Phone: model.phone,
      Email: model.email,
      DateOfWedding: model.dateOfWedding,
      IsGroom: model.isGroom
    };

    return this.http.post<any>(this.url,body).pipe(
      map(user => {
        if (!user.isError) {
          console.log('אני בסרויס',user)
          localStorage.setItem('user', JSON.stringify(model));
          localStorage.setItem('id_user',user.data);
          localStorage.setItem('customer',"true");
          this.updateNavComponent(); 
          this.currentUserSource.next(user);
         
        }
        
      })
    )
  }


  updateNavComponent(): void {
    this.navService.updateNav();
  }
  setCurrentUser(user: any) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.setItem('user','');
    localStorage.setItem('id_user','');
    localStorage.setItem('userDetails','');
    localStorage.setItem('supplier',"false")
    localStorage.setItem('customer',"false"); 
    this.updateNavComponent(); 
  }

}
