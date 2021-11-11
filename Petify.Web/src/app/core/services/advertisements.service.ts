import { Injectable } from '@angular/core';
import { AddAdvertisementCommand } from '@app/shared/models/advertisement.model';
import { Observable } from 'rxjs';
import { ApiClientService } from './api-client.service';

@Injectable({
    providedIn: 'root'
})
export class AdvertisementsService {

    constructor(private _apiClientService: ApiClientService) { }

    addAdvertisement(command: AddAdvertisementCommand): Observable<void> {
        return this._apiClientService.post(`${appConfig.apiUrl}/advertisements`, { data: command });
    }
}
