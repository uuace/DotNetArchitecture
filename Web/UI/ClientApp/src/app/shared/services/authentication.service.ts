import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationModel } from "../models/authentication.model";

@Injectable({ providedIn: "root" })
export class AuthenticationService {
	private service = "AuthenticationService";
	private token = "token";

	constructor(
		private readonly http: HttpClient,
		private readonly router: Router) { }

	authenticate(authentication: AuthenticationModel) {
		this.http.post(`${this.service}/Authenticate`, authentication).subscribe((response: string) => {
			sessionStorage.setItem(this.token, response);
			this.router.navigate(["/home"]);
		});
	}

	getToken() {
		return sessionStorage.getItem(this.token);
	}

	isAuthenticated() {
		return this.getToken() !== null;
	}

	logout() {
		if (this.isAuthenticated()) {
			this.http.post(`${this.service}/Logout`, {}).subscribe();
		}

		sessionStorage.clear();
		this.router.navigate(["/login"]);
	}
}
