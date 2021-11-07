import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'petify-image-preview',
    templateUrl: './image-preview.component.html',
    styleUrls: ['./image-preview.component.scss']
})
export class ImagePreviewComponent implements OnInit {

    @Input() imageUrl: Nullable<string>;
    @Input() height: number;
    @Input() width: number;
    @Input() heightUnit: "px" | "%";
    @Input() widthUnit: "px" | "%";

    constructor() { }

    ngOnInit(): void {
    }

}
