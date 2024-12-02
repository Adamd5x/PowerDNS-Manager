import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  selector: 'app-edit-data-center',
  templateUrl: './edit-data-center.component.html',
  styleUrl: './edit-data-center.component.scss'
})
export class EditDataCenterComponent implements OnInit {

  form = this.fb.group({
    id: [],
    name: ['', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50)
    ]],
    address: ['', [
      Validators.maxLength(150)
    ]],
    city: ['',[
      Validators.maxLength(150)
    ]],
    postalCode: ['', [
      Validators.maxLength(50)
    ]],
    region: ['', [
      Validators.maxLength(50)
    ]],
    country: ['', [
      Validators.maxLength(50)
    ]],
    description:['',[
      Validators.maxLength(250)
    ]]
  });

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    const data = this.route.snapshot.data['datacenter'];
    this.form.setValue(data);
  }

  onSubmit(): void {

  }
}
