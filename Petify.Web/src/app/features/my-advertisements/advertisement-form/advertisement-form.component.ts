import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { DateFilterFn } from '@angular/material/datepicker';
import { UrlSegment } from '@angular/router';
import { AuthService } from '@app/auth';
import { PetService } from '@app/core/services/pet.service';
import { AdvertisementTypes, PetItemDTO } from '@app/shared/models/pet.model';
import { Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';

@Component({
    selector: 'petify-advertisement-form',
    templateUrl: './advertisement-form.component.html',
    styleUrls: ['./advertisement-form.component.scss']
})
export class AdvertisementFormComponent implements OnInit {
    pets$: Observable<PetItemDTO[]>;

    AdvertisementTypes = AdvertisementTypes;

    advertisementTypeId$: Observable<number>;
    advertisementFormGroup = this._fb.group({
        name: ["", Validators.required],
        description: ["", Validators.required],
        advertisementTypeId: [null, Validators.required],
        pets: this._fb.array([]),
        startDate: null,
        endDate: null,
        cyclicalAssistanceFrequency: null
    })

    constructor(
        private _fb: FormBuilder,
        private _authService: AuthService,
        private _petService: PetService) { }

    ngOnInit(): void {
        const userId = this._authService.id as string;
        this.pets$ = this._petService.getPets(userId).pipe(shareReplay());

        this.advertisementTypeId$ = this.advertisementFormGroup.controls.advertisementTypeId.valueChanges.pipe(shareReplay());
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
}
