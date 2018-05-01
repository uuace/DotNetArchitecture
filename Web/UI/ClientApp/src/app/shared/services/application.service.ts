import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReplaySubject } from "rxjs/ReplaySubject";

@Injectable()
export class ApplicationService {
	private application = new ReplaySubject(1);
	private service = "/ApplicationService";

	constructor(private readonly http: HttpClient) { }

	get() {
		if (!this.application.observers.length) {
			this.http.get(this.service).subscribe(
				(response: any) => {
					this.application.next(response);
				},
				(error: any) => {
					this.application.error(error);
					this.application = new ReplaySubject(1);
				});
		}

		return this.application;
	}
}
