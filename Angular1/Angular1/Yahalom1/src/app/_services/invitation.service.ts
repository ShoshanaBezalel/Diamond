import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvitationDTO } from './InvitationDTO'
import { CustomerDTO } from './CustomerDTO';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {
  private apiUrl = 'https://localhost:44369'; // Replace with the actual API URL
  arrOrders:any[] | undefined
  constructor(private http: HttpClient) { }

  // getSupplierInvitations(supplierId: number, status:number): Observable<any[]> {
  //   const url = `${this.apiUrl}/api/Invitation/getInvitationSupplier/getInvitationSupplier/IdSupplier=${supplierId}&inventionStatus=${status}`; // Replace with the actual API endpoint URL
  //   return this.http.get<any[]>(url);
  
  // }
  
  getSupplierInvitations(supplierId: number, status: number): Observable<any> {
    console.log(status,supplierId)

     const url=`https://localhost:44369/api/Invitation/getInvitationSupplier/getInvitationSupplier/${supplierId}?inventationStatus=${status}`

    return this.http.get<any>(url);
  }

  
  getInvitationDetails(invitationId: number): Observable<any[]> {
    const url = `${this.apiUrl}/api/Invitation/getInvitationDetails/${invitationId}`; // Replace with the actual API endpoint URL
    return this.http.get<any[]>(url);
  }

  getCustomerDetails(invitationId: number): Observable<any> {
    const url = `${this.apiUrl}/api/Invitation/getCustomerDetails?idInvitation=${invitationId}`; // Replace with the actual API endpoint  
    return this.http.get<any[]>(url);
  }
  
getInvitation_to_Customer(user_id: number): Observable<any> {
  const url = `https://localhost:44369/api/Invitation/getInvitationCustomer?idCustomer=${user_id}`;
  return this.http.get<any>(url);
}

UpdateIsPaid(idInvitation:number): Observable<any> {
  const url = `${this.apiUrl}/api/Invitation/UpdateIsPaid?idInvitation=${idInvitation}`;
  return this.http.put(url,idInvitation);
}

CreateInvitationCustomer(customer:any){
  const url = `${this.apiUrl}/api/Invitation/CreateInvitationCustomer?DateOfInvitation=${customer.dateOfInvitation}&FinalPrice=${customer.finalPrice}&Location=${customer.location}&StatusId=${customer.statusId}&From=${customer.from}&To=${customer.to}&IdCustomer=${customer.idCustomer}&IdSuplier=${customer.idSuplier}`;
  return this.http.post(url,customer);
}

ContactUs(id:number): Observable<any> {
  const url = `${this.apiUrl}/api/Invitation/ContactUs?idInvitation=${id}`;
  return this.http.get<any>(url);
}
}
