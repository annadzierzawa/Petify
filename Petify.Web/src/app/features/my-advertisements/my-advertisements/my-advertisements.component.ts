import { Component, OnInit } from "@angular/core";
import { AuthService } from "@app/auth/auth.service";
import { AdvertisementsService } from "@app/core/services/advertisements.service";
import { AdvertisementDTO } from "@app/shared/models/advertisement.model";
import { indicate } from "@app/shared/operators/indicate";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { switchMapTo } from "rxjs/internal/operators/switchMapTo";

@Component({
    selector: 'petify-my-advertisements',
    templateUrl: './my-advertisements.component.html',
    styleUrls: ['./my-advertisements.component.scss']
})
export class MyAdvertisementsComponent implements OnInit {

    advertisements$: Observable<AdvertisementDTO[]>;
    private _refreshAdvertisementsSubject$ = new BehaviorSubject({});
    isLoading$ = new Subject<boolean>();

    constructor(
        private _advertisementsService: AdvertisementsService,
        private _authService: AuthService
    ) { }

    ngOnInit(): void {
        const userId = this._authService.id as string;
        this.advertisements$ = this._refreshAdvertisementsSubject$.pipe(
            switchMapTo(this._advertisementsService.getAdvertisements(userId)),
            indicate(this.isLoading$)
        );
    }

    onAdvertisementRemoved(): void {
        this._refreshAdvertisementsSubject$.next({});
    }
}
