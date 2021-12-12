import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { AccountSettingsDTO, UserService } from "@app/core/services/user.service";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { Observable, Subject } from "rxjs";
import { tap } from "rxjs/operators";

@Component({
    selector: 'petify-account-settings',
    templateUrl: './account-settings.component.html',
    styleUrls: ['./account-settings.component.scss']
})
export class AccountSettingsComponent implements OnInit {

    settingsData$: Observable<AccountSettingsDTO>;
    isLoading$ = new Subject<boolean>();

    settingsForm = this._fb.group({
        name: ["", [Validators.required, Validators.minLength(4)]],
        phoneNumber: ["", [Validators.required, Validators.minLength(6)]]
    })

    constructor(
        private readonly _fb: FormBuilder,
        private readonly _toastr: ToastrService,
        private readonly _translate: TranslateService,
        private readonly _userService: UserService) { }

    ngOnInit(): void {
        this.settingsData$ = this._userService.getAccountSettingsData()
            .pipe(
                tap(res => {
                    this.settingsForm.patchValue(res)
                })
            );
    }

    save(): void {
        this._userService.saveAccountSettings(this.settingsForm.value).subscribe(_ => {
            this._toastr.success(this._translate.instant("AccountSettings.DataUpdated"));
        })
    }

}
