import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "@app/material.module";
import { SharedModule } from "@app/shared/shared.module";
import { TranslateModule } from "@ngx-translate/core";

import { AccountSettingsRoutingModule } from "./account-settings-routing.module";
import { AccountSettingsComponent } from "./account-settings.component";


@NgModule({
    declarations: [
        AccountSettingsComponent
    ],
    imports: [
        CommonModule,
        AccountSettingsRoutingModule,
        MaterialModule,
        ReactiveFormsModule,
        TranslateModule,
        SharedModule
    ]
})
export class AccountSettingsModule { }
