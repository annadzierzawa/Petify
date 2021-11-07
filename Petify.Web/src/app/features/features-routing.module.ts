import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";


const routes: Routes = [
    {
        path: "my-pets",
        loadChildren: () => import("./my-pets/my-pets.module").then(m => m.MyPetsModule)
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FeaturesRoutingModule { }
