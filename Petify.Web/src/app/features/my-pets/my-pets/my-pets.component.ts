import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'petify-my-pets',
    templateUrl: './my-pets.component.html',
    styleUrls: ['./my-pets.component.scss']
})
export class MyPetsComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private readonly _router: Router
    ) { }
}
