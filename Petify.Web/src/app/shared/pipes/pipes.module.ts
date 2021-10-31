import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SanitizePipe } from './sanitize.pipe';

const pipes = [SanitizePipe]

@NgModule({
    declarations: pipes,
    exports: pipes,
    providers: pipes,
    imports: [
        CommonModule
    ]
})
export class PipesModule { }
