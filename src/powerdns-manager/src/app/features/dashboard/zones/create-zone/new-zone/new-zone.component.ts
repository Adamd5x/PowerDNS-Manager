import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-new-zone',
  templateUrl: './new-zone.component.html',
  styleUrl: './new-zone.component.scss'
})
export class NewZoneComponent {

  form = this.fb.group({
    serviceId: [''],
    zone: [''],
  });

  constructor(private fb: FormBuilder){}

  onSubmit(): void {
    
  }
}
