import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyAdvertisementsComponent } from './my-advertisements/my-advertisements.component';
import { AdvertisementFormComponent } from './advertisement-form/advertisement-form.component';
import { AddAdvertisementComponent } from './add-advertisement/add-advertisement.component';
import { MyAdvertisementsRoutingModule } from './my-advertisements-routing.module';



@NgModule({
    declarations: [
        MyAdvertisementsComponent,
        AdvertisementFormComponent,
        AddAdvertisementComponent
    ],
    imports: [
        CommonModule,
        MyAdvertisementsRoutingModule
    ]
})
export class MyAdvertisementsModule { }
