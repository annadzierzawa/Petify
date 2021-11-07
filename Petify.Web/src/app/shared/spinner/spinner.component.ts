import { Component, Input } from "@angular/core";
import { ThemePalette } from "@angular/material/core";

@Component({
    selector: "petify-spinner",
    templateUrl: "./spinner.component.html",
    styleUrls: ["./spinner.component.scss"]
})
export class SpinnerComponent {
    @Input() color: ThemePalette = "primary";
    @Input() diameter = 100;
    @Input() size: "fill" | "auto" = "fill";
}
