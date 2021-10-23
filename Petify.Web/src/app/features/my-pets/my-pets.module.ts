import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyPetsRoutingModule } from './my-pets-routing.module';
import { MyPetsComponent } from './my-pets/my-pets.component';
import { MaterialModule } from '@app/material.module';
import { TranslateModule, TranslatePipe } from '@ngx-translate/core';

@NgModule({
    declarations: [
        MyPetsComponent
    ],
    imports: [
        CommonModule,
        MyPetsRoutingModule,
        MaterialModule,
        TranslateModule
    ]
})
export class MyPetsModule { }
