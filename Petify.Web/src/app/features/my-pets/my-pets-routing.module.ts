import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddPetComponent } from "./add-pet/add-pet.component";
import { MyPetsComponent } from "./my-pets/my-pets.component";

const routes: Routes = [
    {
        path: "",
        component: MyPetsComponent
    },
    {
        path: "add",
        component: AddPetComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MyPetsRoutingModule { }
