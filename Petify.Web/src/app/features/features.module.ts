import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MaterialModule } from "@app/material.module";

import { LoginModule } from "./account/login/login.module";
import { LogoutModule } from "./account/logout/logout.module";
import { RegisterModule } from "./account/register/register.module";
import { FeaturesRoutingModule } from "./features-routing.module";

@NgModule({
    imports: [
        CommonModule,
        FeaturesRoutingModule,
        MaterialModule,
        LoginModule,
        RegisterModule,
        LogoutModule
    ],
    declarations: [
    ],
    exports: [
    ]
})
export class FeaturesModule { }
