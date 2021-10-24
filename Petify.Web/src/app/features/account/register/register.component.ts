import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "@app/auth";
import { UserService } from "@app/core/services/user.service";
import { indicate } from "@app/shared/operators";
import { ToastrService } from "ngx-toastr";
import { Subject } from "rxjs";
import { switchMap } from "rxjs/operators";

import { PasswordValidator } from "./password-strength.validator";

@Component({
    selector: "petify-register",
    templateUrl: "./register.component.html"
})
export class RegisterComponent {

    isLoading$ = new Subject<boolean>();

    registerForm = this._fb.group({
        name: ["", [Validators.required, Validators.minLength(6)]],
        email: ["", [Validators.required, Validators.email]],
        phoneNumber: ["", [Validators.required, Validators.minLength(6)]],
        password: ["", [PasswordValidator.strength]],
        confirmPassword: ["", [Validators.required]]
    }, {
        validators: PasswordValidator.confirmed("password", "confirmPassword")
    });

    constructor(
        private _fb: FormBuilder,
        private _authService: AuthService,
        private _userService: UserService,
        private _toastr: ToastrService,
        private _router: Router) { }

    register(): void {
        if (this.registerForm.valid) {
            this._authService.register({
                email: this.registerForm.value.email,
                password: this.registerForm.value.password,
                redirectUrl: `${appConfig.clientUrl}/login`
            }).pipe(
                switchMap(result => this._userService.initUserInSystem({
                    userId: result.userId,
                    email: this.registerForm.value.email,
                    name: this.registerForm.value.name,
                    phoneNumber: this.registerForm.value.phoneNumber
                })),
                indicate(this.isLoading$))
                .subscribe(_ => {
                    this._toastr.success("A verification link has been sent to your email account", "Thank you for registering");
                    this._router.navigate(["login"]);
                }, error => {
                    this._toastr.error(error.error[0].description);
                });
        }
    }
}
