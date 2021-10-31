import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({
    name: 'sanitize'
})
export class SanitizePipe implements PipeTransform {
    transform(value: string): any {
        return this._domSanitizationService.bypassSecurityTrustUrl(value);
    }

    constructor(private _domSanitizationService: DomSanitizer) { }
}
