import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { PetService } from "@app/core/services/pet.service";
import { LookupDTO } from "@app/shared/models/lookup.model";
import { Observable } from "rxjs";

@Component({
    selector: 'petify-ads-filter',
    templateUrl: './ads-filter.component.html',
    styleUrls: ['./ads-filter.component.scss']
})
export class AdsFilterComponent implements OnInit {

    cyclicalAssistance = true;
    oneTimeHelp = true;
    temporaryAdoption = true;

    filtersFormGroup = this._fb.group({
        species: this._fb.control([]),
        types: this._fb.control([]),
        startDate: new Date()
    })
    species$: Observable<LookupDTO[]>;

    constructor(
        private readonly _fb: FormBuilder,
        private readonly _petService: PetService
    ) { }

    ngOnInit(): void {
        this.species$ = this._petService.getSpeciesLookup();
    }

    checkboxesChanged(): void {
        console.log(this.cyclicalAssistance + ", " + this.oneTimeHelp + ", " + this.temporaryAdoption);
    }

}
