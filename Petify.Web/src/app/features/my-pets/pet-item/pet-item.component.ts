import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PetDTO, PetItemDTO } from '@app/shared/models/pet.model';
import { MatDialog } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { ConfirmDialogComponent } from '@app/shared/confirm-dialog/confirm-dialog.component';
import { TranslateService } from '@ngx-translate/core';
import { indicate } from '@app/shared/operators';
import { BehaviorSubject } from 'rxjs';
import { PetService } from '@app/core/services/pet.service';
import { filter, switchMapTo } from 'rxjs/operators';

@Component({
    selector: 'petify-pet-item',
    templateUrl: './pet-item.component.html',
    styleUrls: ['./pet-item.component.scss']
})
export class PetItemComponent {
    @Input() pet: PetItemDTO;
    @Output() petRemoved = new EventEmitter();
    loading$ = new BehaviorSubject<boolean>(false);

    constructor(
        private readonly _matDialog: MatDialog,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _petService: PetService
    ) { }

    onDeletePet(): void {
        this._matDialog.open(ConfirmDialogComponent, {
            maxWidth: "450px",
            panelClass: "dialog-panel-styles",
            data: {
                title: this._translate.instant("MyPets.ConfirmTheOperation"),
                message: this._translate.instant("MyPets.AreYouSureYouWantToDeleteTheAnimal?"),
            }
        }).afterClosed().pipe(
            filter(res => !!res),
            switchMapTo(
                this._petService.removePet(this.pet.id)
                    .pipe(indicate(this.loading$))
            )
        ).subscribe(_ => {
            this.petRemoved.emit();
            this._toastr.success(this._translate.instant("MyPets.TheAnimalHasBeenRemoved"));
        });
    }
}

