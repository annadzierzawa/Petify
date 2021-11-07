import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ImageCroppedEvent } from 'ngx-image-cropper';

export interface CropperConfig {
    event: Event;
    aspectRatio?: number;
    maintainAspectRatio?: boolean;
    roundCropper: boolean;
}

@Component({
    selector: 'petify-image-cropper-dialog',
    templateUrl: './image-cropper-dialog.component.html',
    styleUrls: ['./image-cropper-dialog.component.scss']
})
export class ImageCropperDialogComponent {

    defaultConfig = {
        aspectRatio: 1,
        maintainAspectRatio: true
    };

    private _image: Nullable<string>;

    constructor(
        public dialogRef: MatDialogRef<ImageCropperDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: CropperConfig
    ) { }

    onImageCropped(event: ImageCroppedEvent): void {
        this._image = event.base64;
    }

    onAccept(): void {
        this.dialogRef.close(this._image);
    }

    onCancel(): void {
        this.dialogRef.close(null);
    }
}
