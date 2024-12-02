import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { CreateNewComponent } from "./create-new/create-new.component";
import { EditDataCenterComponent } from "./edit-data-center/edit-data-center.component";
import { DataCenterResolver } from "./core/resolvers/data-center.resolver";

const routes : Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'create',
        component: CreateNewComponent
    },
    {
        path: ':id',
        component: EditDataCenterComponent,
        resolve: { datacenter: DataCenterResolver}
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class DataCenterRoutingModule{}