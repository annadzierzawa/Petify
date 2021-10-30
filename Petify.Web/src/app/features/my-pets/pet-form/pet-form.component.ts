import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import * as moment from "moment";
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { PetService } from '@app/core/services/pet.service';
import { ToastrService } from 'ngx-toastr';
import { LookupDTO } from '@app/shared/models/lookup.model';

@Component({
    selector: 'petify-pet-form',
    templateUrl: './pet-form.component.html',
    styleUrls: ['./pet-form.component.scss']
})
export class PetFormComponent implements OnInit, OnDestroy {

    @Input() petId: Nullable<number>;
    isSaveButtonDisabled = false;

    species$ = new Observable<any[]>()
    private _destroySubject$ = new Subject();
    speciesLookup$: Observable<LookupDTO[]>;

    now = new Date();
    year = this.now.getFullYear();
    month = this.now.getMonth();
    day = this.now.getDay();

    maxDate = moment({ year: this.year, month: this.month, day: this.day - 1 }).format('YYYY-MM-DD');

    petFormGroup = this._fb.group({
        name: ["", Validators.required],
        description: ["", Validators.required],
        speciesId: [null, Validators.required],
        dateOfBirth: [new Date(), Validators.required]
    });

    constructor(private _fb: FormBuilder,
        private readonly _router: Router,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _petService: PetService) {
    }

    ngOnInit(): void {
        // if (this.petId) {
        //     this._petService.getPet(this.userId,this.petId)
        //     .pipe(indicate(this.isLoading$))
        //     .subscribe(data => {
        //         this.petFormGroup.patchValue(data);
        //     });
        // }

        this.speciesLookup$ = this._petService.getSpeciesLookup();
    }

    ngOnDestroy(): void {
        this._destroySubject$.next();
        this._destroySubject$.complete();
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
