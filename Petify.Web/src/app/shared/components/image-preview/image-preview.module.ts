import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImagePreviewComponent } from './image-preview.component';
import { PipesModule } from '@app/shared/pipes/pipes.module';
import { MaterialModule } from '@app/material.module';



@NgModule({
    declarations: [
        ImagePreviewComponent
    ],
    imports: [
        CommonModule,
        PipesModule,
        MaterialModule
    ],
    exports: [
        ImagePreviewComponent
    ]
})
export class ImagePreviewModule { }
