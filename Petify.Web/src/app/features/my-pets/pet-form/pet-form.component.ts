import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import * as moment from "moment";
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { PetService } from '@app/core/services/pet.service';
import { ToastrService } from 'ngx-toastr';
import { LookupDTO } from '@app/shared/models/lookup.model';
import { takeUntil } from 'rxjs/operators';
import { indicate } from '@app/shared/operators';

@Component({
    selector: 'petify-pet-form',
    templateUrl: './pet-form.component.html',
    styleUrls: ['./pet-form.component.scss']
})
export class PetFormComponent implements OnInit, OnDestroy {

    @Input() petId: Nullable<number>;

    species$ = new Observable<any[]>()
    private _destroySubject$ = new Subject();
    speciesLookup$: Observable<LookupDTO[]>;

    now = new Date();
    year = this.now.getFullYear();
    month = this.now.getMonth();
    day = this.now.getDay();

    isLoading$ = new Subject<boolean>();
    isSending$ = new Subject<boolean>();

    imageSrc: string;

    maxDate = moment({ year: this.year, month: this.month, day: this.day - 1 }).format('YYYY-MM-DD');

    petFormGroup = this._fb.group({
        name: ["", Validators.required],
        description: ["", Validators.required],
        speciesId: [null, Validators.required],
        dateOfBirth: [new Date(), Validators.required],
        image: [""],
    });

    constructor(private _fb: FormBuilder,
        private readonly _router: Router,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _petService: PetService) {
    }

    ngOnInit(): void {
        if (this.petId) {
            this._petService.getPet(this.petId)
                .pipe(indicate(this.isLoading$))
                .subscribe(data => {
                    this.petFormGroup.patchValue(data);
                    this.imageSrc = PetService.petImagesEndpoint + data.imageFileStorageId
                });
        }

        this.speciesLookup$ = this._petService.getSpeciesLookup();

        this.petFormGroup.controls.image.valueChanges.pipe(takeUntil(this._destroySubject$)).subscribe(img => {
            this.imageSrc = img;
        })
    }

    ngOnDestroy(): void {
        this._destroySubject$.next();
        this._destroySubject$.complete();
    }

    onSave(): void {
        if (this.petFormGroup.valid) {
            if (this.petId) {
                this._petService.update({
                    id: this.petId,
                    ...this.petFormGroup.value
                }).pipe(
                    indicate(this.isSending$)
                ).subscribe(_ => {
                    this._toastr.success(this._translate.instant("PetForm.TheAnimalHasBeenSaved"));
                    this.onBack();
                });
            } else {
                this._petService.add(this.petFormGroup.value)
                    .pipe(
                        indicate(this.isSending$)
                    ).subscribe(_ => {
                        this._toastr.success(this._translate.instant("PetForm.TheAnimalHasBeenSaved"));
                        this.onBack();
                    });
            }
        }
    }

    onBack(): void {
        this._router.navigate([".."]);
    }
}
