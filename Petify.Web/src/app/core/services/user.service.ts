import { Injectable } from '@angular/core';
import { UserDomain } from '@app/auth';
import { Observable } from 'rxjs';
import { ApiClientService } from './api-client.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private _apiClientService: ApiClientService) { }

    initUserInSystem(user: UserDomain): Observable<UserDomain> {
        return this._apiClientService.post(`${appConfig.apiUrl}/users/init-user`, { data: user });
    }
}
