import { defer, Observable, Subject } from "rxjs";
import { finalize } from "rxjs/operators";

const prepare = <T>(callback: () => void) => {
    return (source: Observable<T>): Observable<T> => defer(() => {
        callback();
        return source;
    });
};

export const indicate = <T>(indicator: Subject<boolean>) => {
    return (source: Observable<T>): Observable<T> => source.pipe(
        prepare(() => indicator.next(true)),
        finalize(() => indicator.next(false))
    );
};
