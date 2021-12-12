import { Component, Input } from "@angular/core";
import { AdvertisementDTO } from "@app/shared/models/advertisement.model";
import { AdvertisementTypes } from "@app/shared/models/pet.model";

@Component({
    selector: 'petify-ads-result-item',
    templateUrl: './ads-result-item.component.html',
    styleUrls: ['./ads-result-item.component.scss']
})
export class AdsResultItemComponent {
    @Input() advertisement: AdvertisementDTO;
    AdvertisementTypes = AdvertisementTypes;
}
