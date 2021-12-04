import { Component, EventEmitter, Input, Output } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { ConfirmDialogComponent } from "@app/shared/confirm-dialog/confirm-dialog.component";
import { AdvertisementDTO } from "@app/shared/models/advertisement.model";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { filter, switchMapTo } from "rxjs/operators";

@Component({
    selector: 'petify-advertisement-item',
    templateUrl: './advertisement-item.component.html',
    styleUrls: ['./advertisement-item.component.scss']
})
export class AdvertisementItemComponent {
    @Input() advertisement: AdvertisementDTO;
    @Output() advertisementRemoved = new EventEmitter();


    constructor(
        private readonly _matDialog: MatDialog,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _advertisementsService: AdvertisementsService,
    ) {
    }

    deleteAdvertisementClicked(): void {
        this._matDialog.open(ConfirmDialogComponent, {
            maxWidth: "450px",
            panelClass: "dialog-panel-styles",
            data: {
                title: this._translate.instant("Common.ConfirmTheOperation"),
                message: this._translate.instant("MyAdvertisements.AreYouSureYouWantToDeleteTheAdvertisement"),
            }
        }).afterClosed().pipe(
            filter(res => !!res),
            switchMapTo(
                this._advertisementsService.removeAdvertisement(this.advertisement.id)
            )
        ).subscribe(_ => {
            this.advertisementRemoved.emit();
            this._toastr.success(this._translate.instant("MyAdvertisements.TheAdertisementHasBeenRemoved"));
        });
    }
}
