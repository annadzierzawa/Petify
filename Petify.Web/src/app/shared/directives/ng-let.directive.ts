import { Directive, Input, TemplateRef, ViewContainerRef } from "@angular/core";

export interface NgLet {
    ngLet: any;
}
/* tslint:disable: directive-selector */
@Directive({
    selector: "[ngLet]"
})
/* tslint:enable: directive-selector */
export class NgLetDirective {
    @Input()
    set ngLet(value: any) {
        this._viewContainerRef.clear();
        this._viewContainerRef.createEmbeddedView(this._templateRef, {
            ngLet: value
        });
    }
    constructor(
        private readonly _viewContainerRef: ViewContainerRef,
        private readonly _templateRef: TemplateRef<NgLet>
    ) { }
}
