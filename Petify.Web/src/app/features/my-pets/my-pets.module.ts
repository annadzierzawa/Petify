import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { PetItemModule } from "@app/shared/components/pet-item/pet-item.module";
import { PipesModule } from "@app/shared/pipes/pipes.module";
import { SharedModule } from "@app/shared/shared.module";
import { TranslateModule } from "@ngx-translate/core";

import { AddPetComponent } from "./add-pet/add-pet.component";
import { EditPetComponent } from "./edit-pet/edit-pet.component";
import { MyPetsRoutingModule } from "./my-pets-routing.module";
import { MyPetsComponent } from "./my-pets/my-pets.component";
import { PetFormComponent } from "./pet-form/pet-form.component";

@NgModule({
    declarations: [
        MyPetsComponent,
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
        PipesModule,
        PetItemModule
    ]
})
export class MyPetsModule { }
