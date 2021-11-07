import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageUploadComponent } from './image-upload.component';
import { ImageCropperDialogComponent } from './image-cropper-dialog/image-cropper-dialog.component';
import { MaterialModule } from '@app/material.module';
import { ImageCropperModule } from 'ngx-image-cropper';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
    declarations: [
        ImageUploadComponent,
        ImageCropperDialogComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        ImageCropperModule,
        TranslateModule
    ],
    exports: [
        ImageUploadComponent
    ]
})
export class ImageUploadModule { }
