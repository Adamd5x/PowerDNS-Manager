import { ChangeDetectionStrategy, Component,
          Inject } from '@angular/core';
import { MatDialogModule,
         MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [
    MatDialogModule,
    MatButtonModule
  ],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DeleteDialogComponent {  
  constructor(@Inject(MAT_DIALOG_DATA) public data: {title: string, message: string}) {
  }
}
