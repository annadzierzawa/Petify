import { Pipe, PipeTransform } from '@angular/core';
import { PetService } from '@app/core/services/pet.service';

@Pipe({
    name: 'petImageUrl'
})
export class PetImageUrlPipe implements PipeTransform {

    transform(imageFileStorageId: string): string {
        return PetService.petImagesEndpoint + imageFileStorageId;
    }
}
