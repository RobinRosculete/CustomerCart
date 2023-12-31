import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { FormGroup, FormControl } from "@angular/forms";
import { environment } from "src/environments/environment";
import { Orders } from "../models/order.interface";

@Component({
  selector: "app-update-orders",
  templateUrl: "./update-orders.component.html",
  styleUrls: ["./update-orders.component.css"],
})
export class UpdateOrdersComponent {
  // the view title
  title?: string;
  order?: Orders;
  orderIds?: number[];
  selectedOrderId?: number;
  // the form model
  form!: FormGroup;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.form = new FormGroup({
      orderId: new FormControl(""),
      product: new FormControl(""),
      orderDate: new FormControl(""),
      totalAmount: new FormControl(""),
    });

    this.getOrderIDs();
  }
  getOrderIDs() {
    var url = environment.endpoint + "api/Orders/order-ids";
    this.http.get<number[]>(url).subscribe((result) => {
      this.orderIds = result;
    });
  }

  onOrderIdSelected() {
    if (this.selectedOrderId !== undefined) {
      this.loadData(this.selectedOrderId);
    }
  }

  loadData(selectedId: number) {
    const url = environment.endpoint + "api/Orders/" + selectedId;
    console.log("URL:", url);

    this.http.get<Orders>(url).subscribe((result) => {
      this.order = result;
      this.title = "Edit - " + this.order.product;

      // Update form with order details
      this.form.patchValue(this.order);
    });
  }

  onSubmit() {
    console.log("Submit button clicked!");
    const order = this.order;
    if (order) {
      order.product = this.form.controls["product"].value;
      order.OrderDate = this.form.controls["orderDate"].value;
      order.TotalAmount = +this.form.controls["totalAmount"].value; // Make sure it's 'totalAmount' instead of 'TotalAmount'

      const url = environment.endpoint + "api/Orders/" + this.selectedOrderId;
      this.http.put<Orders>(url, order).subscribe({
        next: (result) => {
          console.log("Order " + order.orderId + " has been updated.");

          // Go back to Orders view
          this.router.navigate(["/view-orders"]);
        },
        error: (error) => {
          console.error(error);
        },
      });
    } else {
      console.log("Order DNE ");
    }
  }
}
