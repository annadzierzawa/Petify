import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { DateFilterFn } from "@angular/material/datepicker";
import { Router } from "@angular/router";
import { AuthService } from "@app/auth";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { PetService } from "@app/core/services/pet.service";
import { AdvertisementTypes, PetItemDTO } from "@app/shared/models/pet.model";
import { indicate } from "@app/shared/operators/indicate";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { Observable, Subject } from "rxjs";
import { map, shareReplay, switchMap, takeUntil } from "rxjs/operators";

@Component({
    selector: 'petify-advertisement-form',
    templateUrl: './advertisement-form.component.html',
    styleUrls: ['./advertisement-form.component.scss']
})
export class AdvertisementFormComponent implements OnInit, OnDestroy {

    @Input() advertisementId: Nullable<number>;

    pets$: Observable<PetItemDTO[]>;
    AdvertisementTypes = AdvertisementTypes;

    isSending$ = new Subject<boolean>();

    advertisementTypeId$: Observable<number>;
    advertisementFormGroup = this._fb.group({
        title: ["", Validators.required],
        description: ["", Validators.required],
        advertisementTypeId: [null, Validators.required],
        pets: this._fb.array([]),
        startDate: null,
        endDate: null,
        cyclicalAssistanceFrequency: null
    })

    private _destroySubject$ = new Subject();

    constructor(
        private _fb: FormBuilder,
        private _authService: AuthService,
        private readonly _router: Router,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private _petService: PetService,
        private _advertisementService: AdvertisementsService) { }

    ngOnInit(): void {
        const userId = this._authService.id as string;
        this.pets$ = this._petService.getPets(userId).pipe(shareReplay());

        if (!!this.advertisementId) {
            this._advertisementService.getAdvertisementForEditing(userId, this.advertisementId)
                .pipe(takeUntil(this._destroySubject$))
                .subscribe(ad => {
                    this.advertisementFormGroup.patchValue(ad);
                });
        }

        this.advertisementTypeId$ = this.advertisementFormGroup.controls.advertisementTypeId.valueChanges.pipe(shareReplay());
    }

    ngOnDestroy(): void {
        this._destroySubject$.next()
    }

    datesFilter: DateFilterFn<Date | null> = (date: any | null) => {
        const frequency = this.advertisementFormGroup.value.cyclicalAssistanceFrequency;
        const startDate = new Date(this.advertisementFormGroup.value.startDate);

        if (!frequency || !startDate || !date) {
            return false;
        }

        const oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds

        const diffDays = Math.round(Math.abs((startDate.getTime() - date._d.getTime()) / oneDay));
        return diffDays % frequency === 0;
    }

    onSave(): void {
        if (this.advertisementFormGroup.valid) {
            if (this.advertisementId) {
                this.pets$.pipe(map(pets => pets.filter(p => p.isChecked)),
                    switchMap(pets =>
                        this._advertisementService.updateAdvertisement({
                            id: this.advertisementId,
                            ...this.advertisementFormGroup.value,
                            petIds: pets.map(p => p.id)
                        })),
                    indicate(this.isSending$)
                ).subscribe(_ => {
                    this._toastr.success(this._translate.instant("AdvertisementForm.TheAdvertisementHasBeenSaved"));
                    this.onBack();
                });
            } else {
                this.pets$.pipe(map(pets => pets.filter(p => p.isChecked)),
                    switchMap(pets =>
                        this._advertisementService.addAdvertisement({
                            ...this.advertisementFormGroup.value,
                            petIds: pets.map(p => p.id)
                        })),
                    indicate(this.isSending$)
                ).subscribe(_ => {
                    this._toastr.success(this._translate.instant("AdvertisementForm.TheAdvertisementHasBeenSaved"));
                    this.onBack();
                });
            }
        }
    }

    onBack(): void {
        this._router.navigate(["../my-advertisements"]);
    }
}
