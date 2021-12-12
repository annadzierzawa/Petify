import { Injectable } from "@angular/core";
import { UserDomain } from "@app/auth";
import { Observable } from "rxjs";

import { ApiClientService } from "./api-client.service";

export interface AccountSettingsDTO {
    name: string;
    phoneNumber: string;
}

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private _apiClientService: ApiClientService) { }

    initUserInSystem(user: UserDomain): Observable<UserDomain> {
        return this._apiClientService.post(`${appConfig.apiUrl}/users/init-user`, { data: user });
    }

    getAccountSettingsData(): Observable<AccountSettingsDTO> {
        return this._apiClientService.get(`${appConfig.apiUrl}/account-settings-data`);
    }

    saveAccountSettings(user: AccountSettingsDTO): Observable<void> {
        return this._apiClientService.post(`${appConfig.apiUrl}/account-settings`, { data: user });
    }
}
