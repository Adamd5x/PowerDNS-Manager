import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class LoadingService {

    private loadingState = new BehaviorSubject<boolean>(false);
    readonly loading$ = this.loadingState
                            .asObservable();

    loadingOn(): void {
        this.loadingState.next(true);
    }

    loadingOff(): void {
        this.loadingState.next(false);
    }
}