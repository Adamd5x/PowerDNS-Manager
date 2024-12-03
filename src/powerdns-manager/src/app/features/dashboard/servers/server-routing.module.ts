import { NgModule } from '@angular/core';
import { RouterModule,
         Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { EditServerComponent } from "./edit-server/edit-server.component";
import { CreateNewComponent } from './create-new/create-new.component';
import { ServerResolver } from './core/resolvers/server.resolver';


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
        component: EditServerComponent,
        resolve: { serverDetails: ServerResolver }
    }    
]

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class ServersRoutingModule{}