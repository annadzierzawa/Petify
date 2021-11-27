import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'petify-edit-pet',
    templateUrl: './edit-pet.component.html'
})
export class EditPetComponent {

    id: number;

    constructor(private _activatedRoute: ActivatedRoute) {
        this.id = parseInt(this._activatedRoute.snapshot.paramMap.get("id") as string, 10);
    }
}
