import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CustomersComponent } from './customers/customers.component';
import { MsalGuard } from '@azure/msal-angular';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'customers',
    component: CustomersComponent,
    canActivate: [MsalGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
