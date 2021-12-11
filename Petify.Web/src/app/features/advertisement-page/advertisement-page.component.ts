import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { AdvertisementDetails } from "@app/shared/models/advertisement.model";
import { Observable } from "rxjs";

@Component({
    selector: 'petify-advertisement-page',
    templateUrl: './advertisement-page.component.html',
    styleUrls: ['./advertisement-page.component.scss']
})
export class AdvertisementPageComponent implements OnInit {

    id: number;
    advertisement$: Observable<AdvertisementDetails>;

    constructor(
        private _activatedRoute: ActivatedRoute,
        private _advertisementsService: AdvertisementsService
    ) {
        this.id = parseInt(this._activatedRoute.snapshot.paramMap.get("id") as string, 10);
    }

    ngOnInit(): void {
        this.advertisement$ = this._advertisementsService.getAdvertisement(this.id);
    }

}
