import { Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
  isOpen = true;

  openClose(): void {
    this.isOpen = !this.isOpen;
  }
}
