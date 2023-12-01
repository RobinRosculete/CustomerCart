import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { environment } from "src/environments/environment";
import { CustomerOrders } from "../models/customerOrders.interface";
@Component({
  selector: "app-view-orders",
  templateUrl: "./view-orders.component.html",
  styleUrls: ["./view-orders.component.css"],
})
export class ViewOrdersComponent {
  orders: CustomerOrders[] = [];

  constructor(http: HttpClient) {
    http
      .get<CustomerOrders[]>(
        environment.endpoint + "api/Orders/customer-orders"
      )
      .subscribe({
        next: (result) => {
          this.orders = result;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }
}
