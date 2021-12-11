import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";


const routes: Routes = [
    {
        path: "",
        redirectTo: "search",
        pathMatch: "full"
    },
    {
        path: "my-pets",
        loadChildren: () => import("./my-pets/my-pets.module").then(m => m.MyPetsModule)
    },
    {
        path: "my-advertisements",
        loadChildren: () => import("./my-advertisements/my-advertisements.module").then(m => m.MyAdvertisementsModule)
    },
    {
        path: "search",
        loadChildren: () => import("./ads-search/ads-search.module").then(m => m.AdsSearchModule)
    },
    {
        path: "advertisement",
        loadChildren: () => import("./advertisement-page/advertisement-page.module").then(m => m.AdvertisementPageModule)
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FeaturesRoutingModule { }
