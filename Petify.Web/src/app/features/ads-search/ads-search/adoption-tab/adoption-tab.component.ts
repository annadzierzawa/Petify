import { Component, OnDestroy } from "@angular/core";
import { FormControl } from "@angular/forms";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import {
    AdvertisementItemDTO,
    AdvertisementsFilters,
    SearchAdvertisementsSearchCriteria
} from "@app/shared/models/advertisement.model";
import { Page } from "@app/shared/models/page.model";
import { indicate } from "@app/shared/operators";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { shareReplay, switchMap } from "rxjs/operators";

@Component({
    selector: 'petify-adoption-tab',
    templateUrl: './adoption-tab.component.html',
    styleUrls: ['./adoption-tab.component.scss']
})
export class AdoptionTabComponent implements OnDestroy {

    pageSize = 10;
    sortCriteria = "StartDate";
    startDateControl = new FormControl(new Date());

    ads$: Observable<Page<AdvertisementItemDTO>>;
    isLoading$ = new Subject<boolean>();
    private _destroySubject$ = new Subject();
    private _searchCriteria$: BehaviorSubject<SearchAdvertisementsSearchCriteria>;

    constructor(private readonly _advertisementService: AdvertisementsService) { }

    ngOnDestroy(): void {
        this._destroySubject$.next();
        this._destroySubject$.complete();
    }

    onFiltersChanged(filters: AdvertisementsFilters): void {
        if (!this._searchCriteria$) {
            this._searchCriteria$ = new BehaviorSubject<SearchAdvertisementsSearchCriteria>(
                { ...filters, pageNumber: 1 });

            this.ads$ = this._searchCriteria$.pipe(
                switchMap(criteria => this._advertisementService.getAdvertisementsForSearch(criteria)),
                indicate(this.isLoading$),
                shareReplay()
            );
        } else {
            this._searchCriteria$.next({ ...filters, pageNumber: 1 });
        }
    }

    onPageChanged(pageNumber: number): void {
        this._searchCriteria$.next({ ...this._searchCriteria$.value, pageNumber });
    }
}
