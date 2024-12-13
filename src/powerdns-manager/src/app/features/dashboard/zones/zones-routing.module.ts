import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { NewZoneComponent } from "./create-zone/new-zone/new-zone.component";

const routes : Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'new',
        component: NewZoneComponent
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports:
    [
        RouterModule
    ]
})
export class ZonesRoutingModule {}