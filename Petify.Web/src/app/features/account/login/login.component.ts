import { Component } from "@angular/core";
import { AuthService } from "@app/auth";

@Component({
    selector: "petify-login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"]
})
export class LoginComponent {
    constructor(private _authService: AuthService) { }

    login(): void {
        this._authService.login();
    }
}
