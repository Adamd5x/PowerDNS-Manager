import { NgModule } from "@angular/core";
import { RouterModule,
         Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { LayoutComponent } from "./layout/layout.component";

const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                component: HomeComponent
            },
            {
                path: 'state',
                loadChildren: () => import('./state/state.module').then(m => m.StateModule)
            },
            {
                path: 'datacenters',
                loadChildren: () => import('./data-centers/data-center.module').then(m => m.DataCenterModule)
            },
            {
                path: 'zones',
                loadChildren: () => import('./zones/zones.module').then(m => m.ZonesModule)
            },
            {
                path: 'servers',
                loadChildren: () => import('./servers/servers.module').then(m => m.ServersModule)
            },
            {
                path: 'templates',
                loadChildren: () => import('./templates/templates.module').then(m => m.TemplatesModule)
            }
        ]
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
export class DashboarRoutingModule {}