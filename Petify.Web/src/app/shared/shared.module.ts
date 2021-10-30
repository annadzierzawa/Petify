import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MaterialModule } from "@app/material.module";
import { TranslateModule } from "@ngx-translate/core";

import { PasswordSwitchTypeDirective } from "./password-switch-type.directive";
import { ValidationFeedbackComponent } from "./validation-feedback/validation-feedback.component";

@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule
    ],
    declarations: [
        ValidationFeedbackComponent,
        PasswordSwitchTypeDirective
    ],
    exports: [
        ValidationFeedbackComponent,
        PasswordSwitchTypeDirective,
        TranslateModule,
        MaterialModule
    ]
})
export class SharedModule { }
