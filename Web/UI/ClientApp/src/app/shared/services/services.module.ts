import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";

import { ApplicationService } from "./application.service";
import { AuthenticationService } from "./authentication.service";
import { ModalService } from "./modal.service";
import { ValidationService } from "./validation.service";

@NgModule({
	imports: [
		HttpClientModule
	],
	providers: [
		ApplicationService,
		AuthenticationService,
		ModalService,
		ValidationService
	]
})
export class ServicesModule { }
