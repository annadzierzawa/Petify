import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MaterialModule } from "@app/material.module";
import { TranslateModule } from "@ngx-translate/core";

import { ImagePreviewModule } from "./components/image-preview/image-preview.module";
import { ImageUploadModule } from "./components/image-upload/image-upload.module";
import { PaginatorModule } from "./components/paginator/paginator.module";
import { ConfirmDialogComponent } from "./confirm-dialog/confirm-dialog.component";
import { DirectivesModule } from "./directives/directives.module";
import { PasswordSwitchTypeDirective } from "./password-switch-type.directive";
import { SpinnerComponent } from "./spinner/spinner.component";
import { ValidationFeedbackComponent } from "./validation-feedback/validation-feedback.component";

@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        DirectivesModule
    ],
    declarations: [
        ValidationFeedbackComponent,
        PasswordSwitchTypeDirective,
        SpinnerComponent,
        ConfirmDialogComponent
    ],
    exports: [
        ValidationFeedbackComponent,
        PasswordSwitchTypeDirective,
        TranslateModule,
        MaterialModule,
        SpinnerComponent,
        DirectivesModule,
        ImageUploadModule,
        ImagePreviewModule,
        PaginatorModule
    ]
})
export class SharedModule { }
