import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PipesModule } from "@app/shared/pipes/pipes.module";
import { SharedModule } from "@app/shared/shared.module";
import { TranslateModule } from "@ngx-translate/core";

import { AddAdvertisementComponent } from "./add-advertisement/add-advertisement.component";
import { AdvertisementFormComponent } from "./advertisement-form/advertisement-form.component";
import { AdvertisementItemComponent } from "./advertisement-item/advertisement-item.component";
import { EditAdvertisementComponent } from "./edit-advertisement/edit-advertisement.component";
import { MyAdvertisementsRoutingModule } from "./my-advertisements-routing.module";
import { MyAdvertisementsComponent } from "./my-advertisements/my-advertisements.component";



@NgModule({
    declarations: [
        MyAdvertisementsComponent,
        AdvertisementFormComponent,
        AddAdvertisementComponent,
        EditAdvertisementComponent,
        AdvertisementItemComponent
    ],
    imports: [
        CommonModule,
        MyAdvertisementsRoutingModule,
        TranslateModule,
        SharedModule,
        ReactiveFormsModule,
        FormsModule,
        PipesModule
    ]
})
export class MyAdvertisementsModule { }
