import { NgModule } from "@angular/core";
import { CoreModule } from "@core/core.module";

import { MatProgressSpinner } from "@angular/material/progress-spinner";

import { LoadingComponent } from "./loading.component";
import { LoadingService } from "./loading.service";

@NgModule({
    declarations: [
        LoadingComponent
    ],
    imports: [
        MatProgressSpinner,
        CoreModule
    ],
    exports:[
        LoadingComponent
    ],
    providers: [
        LoadingService
    ]
})
export class LoadingModule {}