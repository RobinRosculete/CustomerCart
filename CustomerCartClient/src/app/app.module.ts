import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { NavmenuComponent } from "./navmenu/navmenu.component";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { CustomersComponent } from "./customers/customers.component";
import { environment } from "../environments/environment";
import { MsalInterceptor, MsalModule } from "@azure/msal-angular";
import { InteractionType, PublicClientApplication } from "@azure/msal-browser";
import { ViewOrdersComponent } from './view-orders/view-orders.component';
import { AddOrdersComponent } from './add-orders/add-orders.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavmenuComponent,
    CustomersComponent,
    ViewOrdersComponent,
    AddOrdersComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MsalModule.forRoot(
      new PublicClientApplication({
        auth: {
          clientId: environment.clientId,
          authority: environment.authority,
          redirectUri: environment.redirectUri,
          knownAuthorities: [environment.authorityDomain],
        },
        cache: {
          cacheLocation: "localStorage",
          storeAuthStateInCookie: false,
        },
      }),
      {
        interactionType: InteractionType.Redirect,
        authRequest: {
          scopes: ["openid"],
        },
      },
      {
        interactionType: InteractionType.Redirect,
        protectedResourceMap: new Map([
          [environment.endpoint, environment.endpointScopes],
        ]),
      }
    ),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
