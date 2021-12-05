import { Component, OnInit } from "@angular/core";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { AdvertisementItemDTO, SearchAdvertisementsSearchCriteria } from "@app/shared/models/advertisement.model";
import { Page } from "@app/shared/models/page.model";
import { AdvertisementTypes, ALL_SPECIES_ARRAY } from "@app/shared/models/pet.model";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { switchMap } from "rxjs/operators";

@Component({
    selector: 'petify-adoption-tab',
    templateUrl: './adoption-tab.component.html',
    styleUrls: ['./adoption-tab.component.scss']
})
export class AdoptionTabComponent implements OnInit {

    pageSize = 10;
    sortCriteria = "StartDate";

    ads$: Observable<Page<AdvertisementItemDTO>>;
    isLoading$ = new Subject<boolean>();

    private _searchCriteria$ = new BehaviorSubject<SearchAdvertisementsSearchCriteria>({
        pageNumber: 1,
        pageSize: this.pageSize,
        startDate: new Date(),
        speciesIds: ALL_SPECIES_ARRAY,
        typeIds: [AdvertisementTypes.Adoption],
        orderBy: this.sortCriteria
    })

    constructor(private readonly _advertisementService: AdvertisementsService) { }

    ngOnInit(): void {
        this.ads$ = this._searchCriteria$.pipe(
            switchMap(criteria => this._advertisementService.getAdvertisementsForSearch(criteria))
        );
    }

    onPageChanged(pageNumber: number): void {
        this._searchCriteria$.next({ ...this._searchCriteria$.value, pageNumber });
    }
}
