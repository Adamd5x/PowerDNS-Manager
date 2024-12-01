import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { CreateNewComponent } from "./create-new/create-new.component";

const routes : Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'create',
        component: CreateNewComponent
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