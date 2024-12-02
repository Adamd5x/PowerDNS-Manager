import { Injectable } from "@angular/core";
import { BehaviorSubject,
         Observable,
        concatMap,
        finalize, 
        of,
        tap} from "rxjs";

@Injectable()
export class LoadingService {

    private loadingState = new BehaviorSubject<boolean>(false);
    readonly loading$ = this.loadingState
                            .asObservable();

    showLoaderUntilCompleted<TEntity>(observable$: Observable<TEntity>): Observable<TEntity> {
        return of(null).pipe(
            tap(() => this.loadingOn()),
            concatMap(() => observable$),
            finalize(() => this.loadingOff())
        )
    }

    loadingOn(): void {
        this.loadingState
            .next(true);
    }

    loadingOff(): void {
        this.loadingState
            .next(false);
    }
}