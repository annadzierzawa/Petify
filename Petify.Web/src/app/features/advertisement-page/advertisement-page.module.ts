import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
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
        SharedModule
    ]
})
export class AdvertisementPageModule { }
