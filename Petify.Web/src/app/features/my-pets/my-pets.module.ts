import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyPetsRoutingModule } from './my-pets-routing.module';
import { MyPetsComponent } from './my-pets/my-pets.component';
import { TranslateModule, TranslatePipe } from '@ngx-translate/core';
import { PetItemComponent } from './pet-item/pet-item.component';
import { AddPetComponent } from './add-pet/add-pet.component';
import { PetFormComponent } from './pet-form/pet-form.component';
import { SharedModule } from '@app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { EditPetComponent } from './edit-pet/edit-pet.component';
import { PipesModule } from '@app/shared/pipes/pipes.module';

@NgModule({
    declarations: [
        MyPetsComponent,
        PetItemComponent,
        AddPetComponent,
        PetFormComponent,
        EditPetComponent
    ],
    imports: [
        CommonModule,
        MyPetsRoutingModule,
        SharedModule,
        TranslateModule,
        SharedModule,
        ReactiveFormsModule,
        PipesModule
    ]
})
export class MyPetsModule { }
