import { Component, OnInit } from "@angular/core";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { AdvertisementItemDTO, SearchAdvertisementsSearchCriteria } from "@app/shared/models/advertisement.model";
import { Page } from "@app/shared/models/page.model";
import { AdvertisementTypes, ALL_SPECIES_ARRAY } from "@app/shared/models/pet.model";
import { indicate } from "@app/shared/operators";
import { BehaviorSubject, Subject } from "rxjs";
import { Observable } from "rxjs/internal/Observable";
import { switchMap } from "rxjs/operators";

@Component({
    selector: 'petify-other-advertisement-tab',
    templateUrl: './other-advertisement-tab.component.html',
    styleUrls: ['./other-advertisement-tab.component.scss']
})
export class OtherAdvertisementTabComponent implements OnInit {
    pageSize = 10;
    sortCriteria = "StartDate";
    typeIdsForSerach = [AdvertisementTypes.CyclicalAssistance, AdvertisementTypes.OneTimeHelp, AdvertisementTypes.TemporaryAdoption];

    ads$: Observable<Page<AdvertisementItemDTO>>;
    isLoading$ = new Subject<boolean>();
    private _searchCriteria$ = new BehaviorSubject<SearchAdvertisementsSearchCriteria>({
        pageNumber: 1,
        pageSize: this.pageSize,
        startDate: new Date(),
        speciesIds: ALL_SPECIES_ARRAY,
        typeIds: this.typeIdsForSerach,
        orderBy: this.sortCriteria
    })

    constructor(private readonly _advertisementService: AdvertisementsService) { }

    ngOnInit(): void {
        this.ads$ = this._searchCriteria$.pipe(
            switchMap(criteria => this._advertisementService.getAdvertisementsForSearch(criteria)),
            indicate(this.isLoading$)
        );
    }

    onPageChanged(pageNumber: number): void {
        this._searchCriteria$.next({ ...this._searchCriteria$.value, pageNumber });
    }
}
