import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { PetItemModule } from "@app/shared/components/pet-item/pet-item.module";
import { SharedModule } from "@app/shared/shared.module";

import { AdvertisementPageRoutingModule } from "./advertisement-page-routing.module";
import { AdvertisementPageComponent } from "./advertisement-page.component";



@NgModule({
    declarations: [
        AdvertisementPageComponent
    ],
    imports: [
        CommonModule,
        AdvertisementPageRoutingModule,
        SharedModule,
        PetItemModule
    ]
})
export class AdvertisementPageModule { }
