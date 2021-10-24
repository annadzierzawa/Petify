import { NgModule } from "@angular/core";
import { MatMomentDateModule } from "@angular/material-moment-adapter";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatMenuModule } from "@angular/material/menu";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatDatepickerModule } from '@angular/material/datepicker';


@NgModule({
    imports: [
        MatButtonModule,
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatGridListModule,
        MatFormFieldModule,
        MatInputModule,
        MatMenuModule,
        MatDatepickerModule
    ],
    exports: [
        MatButtonModule,
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatGridListModule,
        MatFormFieldModule,
        MatInputModule,
        MatMenuModule,
        MatDatepickerModule
    ]
})
export class MaterialModule { }
