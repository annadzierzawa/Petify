import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'petify-edit-pet',
    templateUrl: './edit-pet.component.html',
    styleUrls: ['./edit-pet.component.scss']
})
export class EditPetComponent implements OnInit {

    id: number;

    constructor(private _activatedRoute: ActivatedRoute) {
        this.id = parseInt(this._activatedRoute.snapshot.paramMap.get("id") as string, 10);
    }

    ngOnInit(): void {
    }

}
