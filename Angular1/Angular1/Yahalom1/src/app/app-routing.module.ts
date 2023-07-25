import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule,
  TitleStrategy,
  RouterStateSnapshot
} from "@angular/router";

import { HomePageComponent } from './_components/home-page/home-page.component';
import { LoginComponent } from './_components/login/login.component';
import { SupplierRegistrationComponent } from './_components/supplier-registration/supplier-registration.component';
import { CustomerRegistrationComponent } from './_bin/bride-categories/customer-registration/customer-registration.component';
import { UserAreaComponent } from './_components/user-area/user-area.component';
import { RetrievingCategoriesComponent } from './_components/retrieving-categories/retrieving-categories.component';
import { ViewInvitationsComponent } from './_components/view-invitations/view-invitations.component';
import { ViewTasksComponent } from './_components/view-tasks/view-tasks.component';
import { UserProfileComponent } from './_components/user-profile/user-profile.component';
import { RegistrationFormComponent } from './_components/registration-form/registration-form.component';
import { ViewCategoriesComponent } from './_components/view-categories/view-categories.component';
import { RetrievingSubcategoriesComponent } from './_bin/bride-categories/retrieving-subcategories/retrieving-subcategories.component';
import { SortCategoriesComponent } from './_components/sort-categories/sort-categories.component';
import { UserProfileSupplierComponent } from './_bin/bride-categories/user-profile-supplier/user-profile-supplier.component';
import { UserAreaSupplierComponent } from './_bin/bride-categories/user-area-supplier/user-area-supplier.component';
import { ContactUsComponent } from './_components/contact-us/contact-us.component';


const routes: Routes = [
  { path:'', redirectTo: 'home', pathMatch: 'full' },
  { path:'home', component: HomePageComponent },
  { path:'login', component: LoginComponent },
  { path: 'supplier', component: SupplierRegistrationComponent },
  { path: 'customer', component: CustomerRegistrationComponent},
  { path: 'user-area', component: UserAreaComponent },
  { path: 'user-area-supplier', component: UserAreaSupplierComponent },
  { path: 'retrieving-categories', component: RetrievingCategoriesComponent},
  { path: 'view-invitations', component: ViewInvitationsComponent},
  { path: 'view-tasks', component: ViewTasksComponent},
  { path: 'user-profile', component: UserProfileComponent},
  { path: 'registration-form', component: RegistrationFormComponent},
  { path: 'supplier-registration', component: SupplierRegistrationComponent},
  { path: 'view-categories', component:ViewCategoriesComponent },
  { path: 'sort-categories', component:SortCategoriesComponent },
  { path: 'user-profile-supplier', component:UserProfileSupplierComponent },
  { path: 'contact-us', component:ContactUsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

