import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';

import { MatProgressSpinner } from "@angular/material/progress-spinner";

import { LoadingComponent } from "./loading.component";
import { LoadingService } from "./loading.service";

@NgModule({
    declarations: [
        LoadingComponent
    ],
    imports: [
        MatProgressSpinner,
        BrowserModule
    ],
    exports:[
        LoadingComponent
    ],
    providers: [
        LoadingService
    ]
})
export class LoadingModule {}