import { NgModule } from "@angular/core";
import { LoadingDirective } from "./loading.directive";
import { NgLetDirective } from "./ng-let.directive";

const directives = [
    LoadingDirective,
    NgLetDirective
];

@NgModule({
    declarations: directives,
    exports: directives
})
export class DirectivesModule { }
