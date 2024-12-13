import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
  isOpen = true;

  @ViewChild(MatSidenav) sidenav!: MatSidenav;

  openClose(): void {
    this.isOpen = !this.isOpen;
  }
}
