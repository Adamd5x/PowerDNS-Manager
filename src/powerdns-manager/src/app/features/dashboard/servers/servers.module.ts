import { NgModule } from "@angular/core";
import { CoreModule } from '@core/core.module';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';

import { LoadingService } from '@shared/components/loading/loading.service';
import { LoadingModule } from "@shared/components/loading/loading.module";

import { SharedModule } from "@shared/shared.module";
import { MaterialsModule } from "@shared/materiald.module";
import { ServersRoutingModule } from "./server-routing.module";

import { ServerService } from "./services/server-service.service";
import { HomeComponent } from "./home/home.component";
import { CreateNewComponent } from './create-new/create-new.component';
import { EditServerComponent } from './edit-server/edit-server.component';
import { WorkingCofigurationComponent } from "./working-cofiguration/working-cofiguration.component";

@NgModule({
    declarations: [
        HomeComponent,
        CreateNewComponent,
        EditServerComponent,
        WorkingCofigurationComponent
    ],
    imports: [
        CoreModule,
        LoadingModule,
        ServersRoutingModule,
        SharedModule,
        MaterialsModule
    ],
    providers: [
        ServerService,
        LoadingService,
        {
            provide:  MAT_DIALOG_DEFAULT_OPTIONS,
            useValue: { hasBackdrop: false }
        }        
    ]
})
export class ServersModule{ }