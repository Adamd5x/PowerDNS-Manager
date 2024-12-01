import { NgModule } from "@angular/core";
import { HomeComponent } from "./home/home.component";

import { SharedModule } from "@shared/shared.module";
import { MaterialsModule } from "@shared/materiald.module";

import { ServersRoutingModule } from "./server-routing.module";

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        ServersRoutingModule,
        SharedModule,
        MaterialsModule
    ]
})
export class ServersModule{}