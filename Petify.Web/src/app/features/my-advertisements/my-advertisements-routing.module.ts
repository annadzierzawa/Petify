import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddAdvertisementComponent } from "./add-advertisement/add-advertisement.component";
import { MyAdvertisementsComponent } from "./my-advertisements/my-advertisements.component";

const routes: Routes = [
    {
        path: "",
        component: MyAdvertisementsComponent
    },
    {
        path: "add",
        component: AddAdvertisementComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MyAdvertisementsRoutingModule { }
