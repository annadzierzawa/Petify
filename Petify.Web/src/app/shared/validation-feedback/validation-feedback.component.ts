import { Component, Input, OnInit, Optional } from "@angular/core";
import { AbstractControl, FormGroupDirective } from "@angular/forms";

interface MinLength {
    requiredLength: number;
}

@Component({
    selector: "app-validation-feedback",
    templateUrl: "./validation-feedback.component.html"
})
export class ValidationFeedbackComponent implements OnInit {
    @Input() control: Nullable<AbstractControl>;
    @Input() controlName: Nullable<string>;

    constructor(@Optional() private _formGroup: FormGroupDirective) { }

    getValidationError(): string {
        if (this.control?.hasError("required")) {
            return "Field is required.";
        } else if (this.control?.hasError("minlength")) {
            return `Field has to have at least ${this.control.getError("minlength").requiredLength} characters.`;
        } else if (this.control?.hasError("maxlength")) {
            return `Field exceeds the character limit ${this.control.getError("maxlength").actualLength} / ${this.control.getError("maxlength").requiredLength}`;
        } else if (this.control?.hasError("email")) {
            return "E-mail format is incorrect.";
        } else if (this.control?.hasError("mask")) {
            return `Incorrect value, required format is ${this.control.getError("mask").requiredMask}`;
        } else if (this.control?.hasError("greaterThan")) {
            return this.control.getError("greaterThan");
        }
        return "";
    }

    ngOnInit(): void {
        if (!this.control && !this.controlName) {
            throw new Error("Validation Feedback must have [control] or [controlName] inputs");
        } else if (this.controlName && this._formGroup) {
            this.control = this._formGroup.form.get(this.controlName);
        }
    }
}
