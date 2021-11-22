import { Component, Input, OnInit } from "@angular/core";
import { AdvertisementDTO } from "@app/shared/models/advertisement.model";

@Component({
    selector: 'petify-advertisement-item',
    templateUrl: './advertisement-item.component.html',
    styleUrls: ['./advertisement-item.component.scss']
})
export class AdvertisementItemComponent implements OnInit {
    @Input() advertisement: AdvertisementDTO;
    constructor() { }

    ngOnInit(): void {
    }

}
