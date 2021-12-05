import { Component } from "@angular/core";
import { NgSelectConfig } from "@ng-select/ng-select";
import { TranslateService } from "@ngx-translate/core";

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html"
})
export class AppComponent {

    constructor(
        private _config: NgSelectConfig,
        private _translate: TranslateService
    ) {
        this._translate.use("pl");
        this.setNgSelectConfig();
    }

    private setNgSelectConfig(): void {
        this._config.appearance = "outline";
    }
}
