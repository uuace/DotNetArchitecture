import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { ModalService } from "../services/modal.service";

@Injectable()
export class CustomErrorHandler implements ErrorHandler {
	constructor(private readonly injector: Injector) { }

	handleError(error: any) {
		if (!error.status) { return; }

		const modalService = this.injector.get(ModalService);
		const router = this.injector.get(Router);

		switch (error.status) {
			case 400: { modalService.alert(error.error); }
			case 401: { router.navigate(["/login"]); }
		}
	}
}
