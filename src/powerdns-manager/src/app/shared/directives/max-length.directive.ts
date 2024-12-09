import { Directive,
         HostListener,
         Input } from '@angular/core';

@Directive({
  selector: '[appMaxLength]'
})
export class MaxLengthDirective {

  @Input()
  maxLength!: number;

  constructor() { }

  @HostListener('input', ['$event'])
  onInput(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.value.length > this.maxLength) {
      input.value = input.value.substring(0, this.maxLength);
    }
  }

}
