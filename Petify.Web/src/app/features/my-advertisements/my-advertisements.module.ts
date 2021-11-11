import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyAdvertisementsComponent } from './my-advertisements/my-advertisements.component';
import { AdvertisementFormComponent } from './advertisement-form/advertisement-form.component';
import { AddAdvertisementComponent } from './add-advertisement/add-advertisement.component';
import { MyAdvertisementsRoutingModule } from './my-advertisements-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '@app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
    declarations: [
        MyAdvertisementsComponent,
        AdvertisementFormComponent,
        AddAdvertisementComponent
    ],
    imports: [
        CommonModule,
        MyAdvertisementsRoutingModule,
        TranslateModule,
        SharedModule,
        ReactiveFormsModule,
    ]
})
export class MyAdvertisementsModule { }
