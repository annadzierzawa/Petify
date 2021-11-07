import {
    ComponentFactory,
    ComponentFactoryResolver,
    ComponentRef,
    Directive,
    Input,
    TemplateRef,
    ViewContainerRef
} from "@angular/core";
import { SpinnerComponent } from "@app/shared/spinner/spinner.component";

@Directive({
    selector: "[petifyLoading]"
})
export class LoadingDirective {

    loadingFactory: ComponentFactory<SpinnerComponent>;
    loadingComponent: ComponentRef<SpinnerComponent>;

    @Input() set petifyLoading(loading: Nullable<boolean>) {
        this._vcRef.clear();
        if (loading) {
            this.loadingComponent = this._vcRef.createComponent(this.loadingFactory);
        } else {
            this._vcRef.createEmbeddedView(this._templateRef);
        }
    }

    constructor(
        private _templateRef: TemplateRef<any>,
        private _vcRef: ViewContainerRef,
        private _componentFactoryResolver: ComponentFactoryResolver) {
        this.loadingFactory = this._componentFactoryResolver.resolveComponentFactory(SpinnerComponent);
    }
}
