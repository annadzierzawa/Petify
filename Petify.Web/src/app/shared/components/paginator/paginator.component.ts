import { Component, EventEmitter, Input, Output, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { Page } from "@app/shared/models/page.model";

@Component({
    selector: 'petify-paginator',
    templateUrl: './paginator.component.html'
})
export class PaginatorComponent {

    @ViewChild("paginator") matPaginator: MatPaginator;

    @Input() set data(value: Nullable<Page<any>>) {
        if (value) {
            if (value.pageNumber === 1) {
                this.matPaginator.firstPage();
            }
            this._totalCount = value.totalCount;
            this._hidden = false;
        }

        if (!value || value.totalCount === 0) {
            this._hidden = true;
        }
    }

    @Input() pageSize = 10;

    @Output() pageChanged = new EventEmitter<number>();

    private _hidden = false;
    private _totalCount: number;
    private _currentTableIndex = 0;

    get currentTableIndex(): number {
        return this._currentTableIndex;
    }

    get totalCount(): number {
        return this._totalCount;
    }

    get hidden(): boolean {
        return this._hidden;
    }

    onPageChanged(pageEvent: PageEvent): void {
        this._currentTableIndex = pageEvent.pageSize * pageEvent.pageIndex;
        this.pageChanged.emit(pageEvent.pageIndex + 1);
    }
}
