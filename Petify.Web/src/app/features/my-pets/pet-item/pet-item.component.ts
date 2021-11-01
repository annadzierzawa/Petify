import { Component, Input, OnInit } from '@angular/core';
import { PetDTO, PetItemDTO } from '@app/shared/models/pet.model';

@Component({
    selector: 'petify-pet-item',
    templateUrl: './pet-item.component.html',
    styleUrls: ['./pet-item.component.scss']
})
export class PetItemComponent {
    @Input() pet: PetItemDTO;
}
