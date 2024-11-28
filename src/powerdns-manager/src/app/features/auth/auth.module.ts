import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from '@angular/forms';

import { MaterialsModule } from "@shared/materiald.module";
import { ShareModule } from "@shared/share.modules";

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from "./login/login.component";


@NgModule({
    imports: [
        ReactiveFormsModule,
        AuthRoutingModule,
        MaterialsModule,
        ShareModule
    ],
    declarations:[
        LoginComponent
    ]
})
export class AuthModule{}