import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyPetsRoutingModule } from './my-pets-routing.module';
import { MyPetsComponent } from './my-pets/my-pets.component';
import { MaterialModule } from '@app/material.module';
import { TranslateModule, TranslatePipe } from '@ngx-translate/core';
import { PetItemComponent } from './pet-item/pet-item.component';
import { AddPetComponent } from './add-pet/add-pet.component';
import { PetFormComponent } from './pet-form/pet-form.component';
import { SharedModule } from '@app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        MyPetsComponent,
        PetItemComponent,
        AddPetComponent,
        PetFormComponent
    ],
    imports: [
        CommonModule,
        MyPetsRoutingModule,
        MaterialModule,
        TranslateModule,
        SharedModule,
        ReactiveFormsModule
    ]
})
export class MyPetsModule { }
