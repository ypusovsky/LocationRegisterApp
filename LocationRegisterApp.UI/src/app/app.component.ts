import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  data: any;

  constructor() {}

  ngOnInit() {
    // this.apiService.getData().subscribe(response => {
    //   this.data = response;
    // });
  }
}
