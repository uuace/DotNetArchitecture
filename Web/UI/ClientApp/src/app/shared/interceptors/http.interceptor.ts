import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import "rxjs/add/operator/do";
import { AuthenticationService } from "../services/authentication.service";

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
	constructor(private readonly injector: Injector) { }

	intercept(request: HttpRequest<any>, next: HttpHandler) {
		const authenticationService = this.injector.get(AuthenticationService);

		let requestUrl = request.url;

		if (!requestUrl.startsWith("http")) {
			requestUrl = document.getElementsByTagName("base")[0].href + requestUrl;
		}

		request = request.clone({
			setHeaders: { Authorization: `Bearer ${authenticationService.getToken()}` },
			url: requestUrl
		});

		return next.handle(request).do((event: HttpEvent<any>) => {
			if (event instanceof HttpResponse) { /* Response */ }
		});
	}
}
