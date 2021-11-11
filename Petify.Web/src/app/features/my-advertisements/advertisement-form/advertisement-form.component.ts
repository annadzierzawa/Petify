import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { AuthService } from '@app/auth';
import { PetService } from '@app/core/services/pet.service';
import { PetItemDTO } from '@app/shared/models/pet.model';
import { Observable } from 'rxjs';

@Component({
    selector: 'petify-advertisement-form',
    templateUrl: './advertisement-form.component.html',
    styleUrls: ['./advertisement-form.component.scss']
})
export class AdvertisementFormComponent implements OnInit {
    pets$: Observable<PetItemDTO[]>;

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
        this.pets$ = this._petService.getPets(userId);
    }

}
