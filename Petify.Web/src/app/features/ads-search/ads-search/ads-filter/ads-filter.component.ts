import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { PetService } from "@app/core/services/pet.service";
import { AdvertisementsFilters } from "@app/shared/models/advertisement.model";
import { LookupDTO } from "@app/shared/models/lookup.model";
import { AdvertisementTypes } from "@app/shared/models/pet.model";
import { Observable, Subject } from "rxjs";
import { takeUntil, tap } from "rxjs/operators";

@Component({
    selector: 'petify-ads-filter',
    templateUrl: './ads-filter.component.html',
    styleUrls: ['./ads-filter.component.scss']
})
export class AdsFilterComponent implements OnInit, OnDestroy {

    @Input() isForAdpotion = false;
    @Output() filtersChanged = new EventEmitter<AdvertisementsFilters>()

    cyclicalAssistance = true;
    oneTimeHelp = true;
    temporaryAdoption = true;

    filtersFormGroup = this._fb.group({
        speciesIds: this._fb.control([]),
        startDate: new Date()
    })

    species$: Observable<LookupDTO[]>;
    private _destroySubject$ = new Subject();
    constructor(
        private readonly _fb: FormBuilder,
        private readonly _petService: PetService
    ) { }

    ngOnInit(): void {
        this.species$ = this._petService.getSpeciesLookup().pipe(
            tap(species => {
                this.filtersFormGroup.controls.speciesIds.patchValue(species.map(s => s.id));
            }));
        this.filtersFormGroup.valueChanges.pipe(takeUntil(this._destroySubject$)).subscribe(_ => {
            this.onFiltersChanged();
        })
    }

    ngOnDestroy(): void {
        this._destroySubject$.next();
        this._destroySubject$.complete();
    }

    onFiltersChanged(): void {
        let typeIds = [] as number[];

        if (this.isForAdpotion) {
            typeIds.push(AdvertisementTypes.Adoption);
        } else {
            if (this.cyclicalAssistance) {
                typeIds.push(AdvertisementTypes.CyclicalAssistance);
            }

            if (this.oneTimeHelp) {
                typeIds.push(AdvertisementTypes.OneTimeHelp);
            }

            if (this.temporaryAdoption) {
                typeIds.push(AdvertisementTypes.TemporaryAdoption);
            }
        }

        const event = {
            ...this.filtersFormGroup.value,
            startDate: new Date(this.filtersFormGroup.value.startDate),
            typeIds
        };
        this.filtersChanged.emit(event);
    }

}
