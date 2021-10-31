import { Injectable } from '@angular/core';
import { LookupDTO } from '@app/shared/models/lookup.model';
import { PetDTO } from '@app/shared/models/pet.model';
import { Observable } from 'rxjs/internal/Observable';
import { ApiClientService } from './api-client.service';

@Injectable({
    providedIn: 'root'
})
export class PetService {

    public static petImagesEndpoint = `${appConfig.apiUrl}/pets/images/`;

    constructor(private _apiClientService: ApiClientService) { }

    add(value: PetDTO): Observable<void> {
        return this._apiClientService.post(`${appConfig.apiUrl}/pets`, { data: value });
    }

    getSpeciesLookup(): Observable<LookupDTO[]> {
        return this._apiClientService.get(`${appConfig.apiUrl}/pets/species-lookup`);
    }

    getPet(id: number): Observable<PetDTO> {
        return this._apiClientService.get(`${appConfig.apiUrl}/pets/{id}`, { segmentParams: { id } });
    }
}
