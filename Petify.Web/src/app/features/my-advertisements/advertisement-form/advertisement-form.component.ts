import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
    selector: 'petify-advertisement-form',
    templateUrl: './advertisement-form.component.html',
    styleUrls: ['./advertisement-form.component.scss']
})
export class AdvertisementFormComponent implements OnInit {

    constructor(private _fb: FormBuilder) { }

    ngOnInit(): void {
    }

}
