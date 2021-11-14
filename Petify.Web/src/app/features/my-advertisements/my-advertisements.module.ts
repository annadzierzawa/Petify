import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyAdvertisementsComponent } from './my-advertisements/my-advertisements.component';
import { AdvertisementFormComponent } from './advertisement-form/advertisement-form.component';
import { AddAdvertisementComponent } from './add-advertisement/add-advertisement.component';
import { MyAdvertisementsRoutingModule } from './my-advertisements-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '@app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PipesModule } from '@app/shared/pipes/pipes.module';



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
        PipesModule,
        FormsModule
    ]
})
export class MyAdvertisementsModule { }
