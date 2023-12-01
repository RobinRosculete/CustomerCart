import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-add-orders",
  templateUrl: "./add-orders.component.html",
  styleUrls: ["./add-orders.component.css"],
})
export class AddOrdersComponent {
  emails: string[] = [];

  constructor(http: HttpClient) {
    http
      .get<string[]>(environment.endpoint + "api/Customers/customer-email")
      .subscribe({
        next: (result) => {
          this.emails = result;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }
}
