import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCommonModule,
       MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatListModule } from '@angular/material/list';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';

import { MatSortModule } from '@angular/material/sort';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatBadgeModule } from '@angular/material/badge';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';

const MATERIALS_MODULES = [
    MatCommonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatDividerModule,
    MatIconModule,
    MatExpansionModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatBottomSheetModule,  
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatListModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatStepperModule,
    MatTableModule,
    MatSortModule,
    MatTabsModule,
    MatTooltipModule,
    MatTreeModule,
    MatSnackBarModule,
    MatSlideToggleModule,
    MatGridListModule,
    MatBadgeModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatNativeDateModule]

@NgModule(
    {
        imports: [
            CommonModule,
            MATERIALS_MODULES
        ],
        exports: [
            MATERIALS_MODULES
        ]
    }
)
export class MaterialsModule {}