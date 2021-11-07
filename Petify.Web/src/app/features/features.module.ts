import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "@app/shared/shared.module";

import { LoginModule } from "./account/login/login.module";
import { LogoutModule } from "./account/logout/logout.module";
import { RegisterModule } from "./account/register/register.module";
import { FeaturesRoutingModule } from "./features-routing.module";

@NgModule({
    imports: [
        CommonModule,
        FeaturesRoutingModule,
        LoginModule,
        RegisterModule,
        LogoutModule,
        SharedModule
    ],
    declarations: [
    ],
    exports: [
    ]
})
export class FeaturesModule { }
