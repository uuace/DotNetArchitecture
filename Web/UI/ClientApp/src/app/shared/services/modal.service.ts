import { Injectable } from "@angular/core";

declare let UIkit: any;

@Injectable()
export class ModalService {
	alert(message: string): void { UIkit.modal.alert(message); }
}
