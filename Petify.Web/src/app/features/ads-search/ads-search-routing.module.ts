import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AdsSearchComponent } from "./ads-search/ads-search.component";

const routes: Routes = [
    {
        path: "",
        component: AdsSearchComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdsSearchRoutingModule { }
