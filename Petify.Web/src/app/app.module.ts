import { HttpClient } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AuthModule } from "@app/auth";
import { LoadingBarHttpClientModule } from "@ngx-loading-bar/http-client";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { HttpLoaderFactory } from "./bootstrap";
import { CoreModule } from "./core/core.module";
import { MainModule } from "./main/main.module";
import { MaterialModule } from "./material.module";

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AuthModule.forRoot(),
        MaterialModule,
        BrowserAnimationsModule,
        CoreModule,
        MainModule,
        AppRoutingModule,
        LoadingBarHttpClientModule,
        TranslateModule.forRoot({
            defaultLanguage: "pl",
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            }
        }),
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
