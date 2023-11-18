import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-customers",
  templateUrl: "./customers.component.html",
  styleUrls: ["./customers.component.css"],
})
export class CustomersComponent {
  customers: Customers[] = [];
  baseUrl: string = "https://customercartapi.azurewebsites.net";

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

interface Customers {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
}
