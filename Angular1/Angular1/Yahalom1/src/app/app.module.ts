import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerRegistrationComponent } from './_bin/bride-categories/customer-registration/customer-registration.component';
import { EnterCustomerComponent } from './_bin/bride-categories/enter-customer/enter-customer.component';
import { EnterSupplierComponent } from './_bin/bride-categories/enter-supplier/enter-supplier.component';
import { HomePageComponent } from './_components/home-page/home-page.component';
import { LoginComponent } from './_components/login/login.component';
import { RetrievingCategoriesComponent } from './_components/retrieving-categories/retrieving-categories.component';
import { RetrievingSubcategoriesComponent } from './_bin/bride-categories/retrieving-subcategories/retrieving-subcategories.component';
import { SuccededRegistrationComponent } from './_bin/bride-categories/succeded-registration/succeded-registration.component';
import { SupplierOrderComponent } from './_bin/bride-categories/supplier-order/supplier-order.component';
import { SupplierRegistrationComponent } from './_components/supplier-registration/supplier-registration.component';
import { ViewInvitationsComponent } from './_components/view-invitations/view-invitations.component';
import { ViewTasksComponent } from './_components/view-tasks/view-tasks.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignupFormComponent } from './_bin/bride-categories/signup-form/signup-form.component';
import { HttpClientModule } from '@angular/common/http';
import { UserAreaComponent } from './_components/user-area/user-area.component';
import { UserProfileComponent } from './_components/user-profile/user-profile.component';
import { GroomCategoriesComponent } from './_bin/bride-categories/groom-categories/groom-categories.component';
import { BrideCategoriesComponent } from './_bin/bride-categories/bride-categories.component';
import { RegistrationFormComponent } from './_components/registration-form/registration-form.component';
import { NavComponent } from './_components/nav/nav.component';
import { ViewCategoriesComponent } from './_components/view-categories/view-categories.component';
import { SortCategoriesComponent } from './_components/sort-categories/sort-categories.component';
import { ViewSupplierComponent } from './_components/view-supplier/view-supplier.component';
import { UserAreaSupplierComponent } from './_bin/bride-categories/user-area-supplier/user-area-supplier.component';
import { UserProfileSupplierComponent } from './_bin/bride-categories/user-profile-supplier/user-profile-supplier.component';
import { InvitationComponent } from './_bin/invitation/invitation.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ContactUsComponent } from './_components/contact-us/contact-us.component';


// import {ModuleOfNgb} from '@ng-bootstrap/ng-bootstrap';  
// import { ModuleOfNg } from '@angular/core'; 


@NgModule({
  declarations: [
    AppComponent,
    CustomerRegistrationComponent,
    EnterCustomerComponent,
    EnterSupplierComponent,
    HomePageComponent,
    LoginComponent,
    RetrievingCategoriesComponent,
    RetrievingSubcategoriesComponent,
    SuccededRegistrationComponent,
    SupplierOrderComponent,
    SupplierRegistrationComponent,
    ViewInvitationsComponent,
    ViewTasksComponent,
    SignupFormComponent,
    UserAreaComponent,
    UserProfileComponent,
    GroomCategoriesComponent,
    BrideCategoriesComponent,
    RegistrationFormComponent,
    NavComponent,
    ViewCategoriesComponent,
    SortCategoriesComponent,
    ViewSupplierComponent,
    UserAreaSupplierComponent,
    UserProfileSupplierComponent,
    InvitationComponent,
    ContactUsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    ReactiveFormsModule,
   
    // ModuleOfBrowser,
    // ModuleOfNgb
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
