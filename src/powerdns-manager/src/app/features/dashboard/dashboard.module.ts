import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';

import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { ManagerErrorHandler } from '@shared/handlers/manager-error-handler';

import { DashboarRoutingModule } from './bashboard-routing.nodule';
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    LayoutComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatToolbarModule,
    DashboarRoutingModule,
    SharedModule,
    MaterialsModule
  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: ManagerErrorHandler
    }
  ]
})
export class DashboardModule { }
