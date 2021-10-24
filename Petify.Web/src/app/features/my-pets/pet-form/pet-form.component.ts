import { Component, OnDestroy, OnInit } from '@angular/core';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from "@angular/material/core";
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from "@angular/material-moment-adapter";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import * as moment from "moment";
import { Observable, Subject } from 'rxjs';
import { MatDatepicker } from '@angular/material/datepicker/datepicker';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr/toastr/toastr.service';
import { TranslateService } from '@ngx-translate/core';
import { PetService } from '@app/core/services/pet.service';

export const MY_FORMATS = {
    parse: {
        dateInput: "MM.YYYY"
    },
    display: {
        dateInput: "MM.YYYY",
        monthYearLabel: "MMM YYYY",
        dateA11yLabel: "LL",
        monthYearA11yLabel: "MMMM YYYY",
    },
};

@Component({
    selector: 'petify-pet-form',
    templateUrl: './pet-form.component.html',
    styleUrls: ['./pet-form.component.scss'],
    providers: [
        {
            provide: DateAdapter,
            useClass: MomentDateAdapter,
            deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
        },

        { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
    ]
})
export class PetFormComponent implements OnInit, OnDestroy {

    petFormGroup: FormGroup;
    isSaveButtonDisabled = false;

    species$ = new Observable<any[]>()
    private _destroySubject$ = new Subject();

    now = new Date();
    year = this.now.getFullYear();
    month = this.now.getMonth();
    day = this.now.getDay();

    maxDate = moment({ year: this.year, month: this.month, day: this.day - 1 }).format('YYYY-MM-DD');


    constructor(private _fb: FormBuilder,
        private readonly _router: Router,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _petService: PetService) {
        this.petFormGroup = this._fb.group({
            name: ["", Validators.required],
            description: ["", Validators.required],
            speciesId: [null, Validators.required],
            dateOfBirth: [null, Validators.required]
        });
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
        this._destroySubject$.next();
        this._destroySubject$.complete();
    }

    chosenYearHandler(normalizedYear: moment.Moment): void {
        const ctrlValue = this.petFormGroup.controls.dateOfBirth.value;
        ctrlValue.year(normalizedYear.year());
        this.petFormGroup.controls.dateOfBirth.setValue(ctrlValue, { emitEvent: false });
    }

    chosenMonthHandler(normalizedMonth: moment.Moment, datepicker: MatDatepicker<moment.Moment>): void {
        const ctrlValue = this.petFormGroup.controls.dateOfBirth.value;
        ctrlValue.month(normalizedMonth.month());
        this.petFormGroup.controls.dateOfBirth.setValue(ctrlValue);
        datepicker.close();
    }

    onSave(): void {
        if (this.petFormGroup.valid) {
            this.isSaveButtonDisabled = true;
            this._petService.add(this.petFormGroup.value).subscribe(_ => {
                this._toastr.success(this._translate.instant("PetForm.TheAnimalHasBeenSaved"));
                this.onBack();
            },
                _ => this.isSaveButtonDisabled = false);
        }
    }

    onBack(): void {
        this._router.navigate([".."]);
    }
}
