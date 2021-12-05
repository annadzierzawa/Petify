import { Injectable } from "@angular/core";
import {
    AddAdvertisementCommand,
    AdvertisementDTO,
    AdvertisementItemDTO,
    SearchAdvertisementsSearchCriteria,
    UpdateAdvertisementCommand
} from "@app/shared/models/advertisement.model";
import { Page } from "@app/shared/models/page.model";
import { Observable } from "rxjs";

import { ApiClientService } from "./api-client.service";

@Injectable({
    providedIn: 'root'
})
export class AdvertisementsService {

    constructor(private _apiClientService: ApiClientService) { }

    addAdvertisement(command: AddAdvertisementCommand): Observable<void> {
        return this._apiClientService.post(`${appConfig.apiUrl}/advertisements`, { data: command });
    }

    updateAdvertisement(command: UpdateAdvertisementCommand): Observable<void> {
        return this._apiClientService.put(`${appConfig.apiUrl}/advertisements/{id}`, {
            data: command,
            segmentParams:
                { id: command.id }
        });
    }

    removeAdvertisement(id: number): Observable<void> {
        return this._apiClientService.delete(`${appConfig.apiUrl}/advertisements/{id}`, { segmentParams: { id } });
    }

    getAdvertisements(userId: string): Observable<AdvertisementDTO[]> {
        return this._apiClientService.get(`${appConfig.apiUrl}/users/{userId}/advertisements`, { segmentParams: { userId } })
    }

    getAdvertisementForEditing(userId: string, advertisementId: number): Observable<AdvertisementDTO> {
        return this._apiClientService.get(`${appConfig.apiUrl}/users/{userId}/advertisements/{advertisementId}/editing-data`, { segmentParams: { userId, advertisementId } })
    }

    getAdvertisementsForSearch(criteria: SearchAdvertisementsSearchCriteria): Observable<Page<AdvertisementItemDTO>> {
        return this._apiClientService.get(`${appConfig.apiUrl}/advertisements/search`, { queryParams: criteria });
    }
}
