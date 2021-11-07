import { Component, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { filter } from 'rxjs/operators';
import { CropperConfig, ImageCropperDialogComponent } from './image-cropper-dialog/image-cropper-dialog.component';

@Component({
    selector: 'petify-image-upload',
    templateUrl: './image-upload.component.html',
    styleUrls: ['./image-upload.component.scss']
})
export class ImageUploadComponent implements ControlValueAccessor {

    @Input() aspectRatio?: number;
    @Input() maintainAspectRatio?: boolean;
    @Input() roundCropper = false;
    @Input() btnDisplayText: string;
    imageAsBase64: string;
    id: string;

    onChange: any = () => { };
    onTouch: any = () => { };

    constructor(
        private _ngControl: NgControl,
        private _dialog: MatDialog,
        private _translateService: TranslateService,
        private _toastr: ToastrService) {
        this._ngControl.valueAccessor = this;
    }

    writeValue(value: string): void {
        this.imageAsBase64 = value;
    }

    registerOnChange(fn: any): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouch = fn;
    }

    handleFileInput(event: Event): void {
        const element = event.currentTarget as HTMLInputElement;
        const fileList: FileList | null = element.files;

        if (fileList && fileList.item(0) && (fileList.item(0) as File).size > 10_000_000 * 4 / 3) {
            this._translateService.get("Common.FileSizeIsTooLarge").subscribe(t => this._toastr.error(t));
        } else {
            const cropperConfig: CropperConfig = {
                event,
                aspectRatio: this.aspectRatio,
                maintainAspectRatio: this.maintainAspectRatio,
                roundCropper: this.roundCropper
            };
            this._dialog.open(ImageCropperDialogComponent, { data: cropperConfig, panelClass: "dialog-panel-styles" })
                .afterClosed()
                .pipe(filter(Boolean))
                .subscribe(result => {
                    this.onChange(result);
                });
        }
    }

    onClick({ target }: MouseEvent): void {
        (target as HTMLInputElement).value = "";
    }
}
