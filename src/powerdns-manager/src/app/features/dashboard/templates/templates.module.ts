import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TemplatesRoutingModule } from './templates-routing.modules';
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    TemplatesRoutingModule,
    SharedModule,
    MaterialsModule
  ]
})
export class TemplatesModule { }
