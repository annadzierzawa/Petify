import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "@app/material.module";
import { PipesModule } from "@app/shared/pipes/pipes.module";
import { TranslateModule } from "@ngx-translate/core";

import { ImagePreviewModule } from "../image-preview/image-preview.module";
import { PetItemComponent } from "./pet-item.component";



@NgModule({
    declarations: [
        PetItemComponent
    ],
    imports: [
        CommonModule,
        ImagePreviewModule,
        RouterModule,
        TranslateModule,
        MaterialModule,
        PipesModule
    ],
    exports: [
        PetItemComponent
    ]
})
export class PetItemModule { }
