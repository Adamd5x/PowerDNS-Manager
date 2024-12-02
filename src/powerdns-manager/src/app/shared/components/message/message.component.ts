import { Component } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'message',
  template: '',
  styleUrl: './message.component.scss'
})
export class MessageComponent {

private snack = new Subject<string>();

message$ = this.snack
               .asObservable();

}
