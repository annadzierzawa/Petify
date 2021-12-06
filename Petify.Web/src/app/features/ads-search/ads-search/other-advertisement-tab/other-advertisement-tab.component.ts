import { Component } from "@angular/core";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import {
    AdvertisementItemDTO,
    AdvertisementsFilters,
    SearchAdvertisementsSearchCriteria
} from "@app/shared/models/advertisement.model";
import { Page } from "@app/shared/models/page.model";
import { indicate } from "@app/shared/operators";
import { BehaviorSubject, Subject } from "rxjs";
import { Observable } from "rxjs/internal/Observable";
import { shareReplay, switchMap } from "rxjs/operators";

@Component({
    selector: 'petify-other-advertisement-tab',
    templateUrl: './other-advertisement-tab.component.html',
    styleUrls: ['./other-advertisement-tab.component.scss']
})
export class OtherAdvertisementTabComponent {
    pageSize = 10;
    sortCriteria = "StartDate";

    ads$: Observable<Page<AdvertisementItemDTO>>;
    isLoading$ = new Subject<boolean>();
    private _searchCriteria$: BehaviorSubject<SearchAdvertisementsSearchCriteria>;

    constructor(private readonly _advertisementService: AdvertisementsService) { }

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
