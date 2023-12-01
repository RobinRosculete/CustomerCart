import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Customers } from "../models/customer.interface";

@Component({
  selector: "app-customers",
  templateUrl: "./customers.component.html",
  styleUrls: ["./customers.component.css"],
})
export class CustomersComponent {
  customers: Customers[] = [];

  constructor(http: HttpClient) {
    http.get<Customers[]>(environment.endpoint + "api/Customers").subscribe({
      next: (result) => {
        this.customers = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
