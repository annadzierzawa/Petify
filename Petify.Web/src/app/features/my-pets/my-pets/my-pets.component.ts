import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@app/auth';
import { PetService } from '@app/core/services/pet.service';
import { PetDTO, PetItemDTO } from '@app/shared/models/pet.model';
import { indicate } from '@app/shared/operators';
import { Observable, Subject } from 'rxjs';

@Component({
    selector: 'petify-my-pets',
    templateUrl: './my-pets.component.html',
    styleUrls: ['./my-pets.component.scss']
})
export class MyPetsComponent implements OnInit {

    pets$: Observable<PetItemDTO[]>;
    isLoading$ = new Subject<boolean>();

    constructor(
        private _petService: PetService,
        private _authService: AuthService
    ) { }

    ngOnInit(): void {
        const userId = this._authService.id as string;
        this.pets$ = this._petService.getPets(userId).pipe(
            indicate(this.isLoading$)
        );
    }
}
