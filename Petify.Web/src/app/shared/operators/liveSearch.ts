import { Observable } from "rxjs";
import { debounceTime, distinctUntilChanged, switchMap } from "rxjs/operators";

export const defaultDelay = 400;

export function liveSearch<T, R>(
    data: (query: T) => Observable<R>,
    delay = defaultDelay
): (source: Observable<T>) => Observable<R> {
    return (source$: Observable<T>) => source$.pipe(
        debounceTime(delay),
        distinctUntilChanged(),
        switchMap(data)
    );
}
