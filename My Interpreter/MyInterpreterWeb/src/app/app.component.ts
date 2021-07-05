import { Component } from '@angular/core';
import * as keys from './shared/apikey';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MyInterpreterWeb';
  message = keys.Yandex;
}
