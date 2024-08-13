import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header-admin',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header-admin.component.html',
  styleUrl: './header-admin.component.css',
})
export class HeaderAdminComponent implements OnInit, OnDestroy {
  usuName = 'Rubén Dario Carrillo Lopez';
  usuEmail = 'allenmoreno@gmail.com';
  ngOnInit(): void {}
  ngOnDestroy(): void {}
}
