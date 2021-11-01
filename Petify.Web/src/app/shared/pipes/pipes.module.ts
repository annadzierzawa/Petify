import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SanitizePipe } from './sanitize.pipe';
import { PetImageUrlPipe } from './pet-image-url.pipe';

const pipes = [SanitizePipe, PetImageUrlPipe]

@NgModule({
    declarations: pipes,
    exports: pipes,
    providers: pipes,
    imports: [
        CommonModule
    ]
})
export class PipesModule { }
