import { Component } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';

@Component({
  selector: 'app-create-new',
  templateUrl: './create-new.component.html',
  styleUrl: './create-new.component.scss'
})
export class CreateNewComponent {

  form = this.fb.group({
    name: [''],
    address: [''],
    city: [''],
    postalCore: [''],
    region: [''],
    country: ['']
  });

  constructor(private fb: NonNullableFormBuilder){}
}
