import { ErrorHandler } from "@angular/core";

export class ManagerErrorHandler implements ErrorHandler {
    handleError(error: any): void {
        console.error(error);
    }
}