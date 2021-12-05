import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from "@app/shared/shared.module";
import { NgSelectModule } from "@ng-select/ng-select";

import { AdsSearchRoutingModule } from "./ads-search-routing.module";
import { AdoptionTabComponent } from "./ads-search/adoption-tab/adoption-tab.component";
import { AdsFilterComponent } from "./ads-search/ads-filter/ads-filter.component";
import { AdsResultItemComponent } from "./ads-search/ads-result-item/ads-result-item.component";
import { AdsSearchComponent } from "./ads-search/ads-search.component";
import { OtherAdvertisementTabComponent } from "./ads-search/other-advertisement-tab/other-advertisement-tab.component";


@NgModule({
    declarations: [
        AdsSearchComponent,
        AdsFilterComponent,
        AdoptionTabComponent,
        AdsResultItemComponent,
        OtherAdvertisementTabComponent
    ],
    imports: [
        CommonModule,
        AdsSearchRoutingModule,
        SharedModule,
        NgSelectModule,
        ReactiveFormsModule,
        FormsModule
    ]
})
export class AdsSearchModule { }
