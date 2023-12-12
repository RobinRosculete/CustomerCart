import { Injectable } from "@angular/core";
import { PublicClientApplication, InteractionType } from "@azure/msal-browser";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class AuthenticationService {
  msalInstance: PublicClientApplication;

  constructor() {
    this.msalInstance = new PublicClientApplication({
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
    });
  }

  getMsalInstance() {
    return this.msalInstance;
  }

  getAuthRequestScopes() {
    return {
      interactionType: InteractionType.Redirect,
      authRequest: {
        scopes: ["openid"],
      },
    };
  }

  getProtectedResourceMap() {
    return {
      interactionType: InteractionType.Redirect,
      protectedResourceMap: new Map([
        [environment.endpoint, environment.endpointScopes],
      ]),
    };
  }
}
