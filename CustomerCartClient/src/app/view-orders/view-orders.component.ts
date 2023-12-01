import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-view-orders",
  templateUrl: "./view-orders.component.html",
  styleUrls: ["./view-orders.component.css"],
})
export class ViewOrdersComponent {
  orders: Orders[] = [];

  constructor(http: HttpClient) {
    http
      .get<Orders[]>(environment.endpoint + "api/Orders/customer-orders")
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

interface Orders {
  firstName: string;
  lastName: string;
  email: string;
  orderDate: string;
  orderAmount: number;
  totalSpent: number;
}
