import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { CustomersComponent } from "./customers/customers.component";
import { ViewOrdersComponent } from "./view-orders/view-orders.component";
import { MsalGuard } from "@azure/msal-angular";
import { UpdateOrdersComponent } from "./update-orders/update-orders.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "customers",
    component: CustomersComponent,
    canActivate: [MsalGuard],
  },
  {
    path: "view-orders",
    component: ViewOrdersComponent,
    canActivate: [MsalGuard],
  },
  {
    path: "update-orders",
    component: UpdateOrdersComponent,
    canActivate: [MsalGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
