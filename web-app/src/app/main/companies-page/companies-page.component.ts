import { Component } from '@angular/core';
import { HeaderMainComponent } from '../templates/header-main/header-main.component';
import { FooterMainComponent } from '../templates/footer-main/footer-main.component';
import { NewCompanyComponent } from './new-company/new-company.component';
import { CarouselCompaniesComponent } from './carousel-companies/carousel-companies.component';
import { NoticesCompaniesComponent } from './notices-companies/notices-companies.component';

@Component({
  selector: 'app-companies-page',
  standalone: true,
  imports: [
    HeaderMainComponent,
    FooterMainComponent,
    NewCompanyComponent,
    CarouselCompaniesComponent,
    NoticesCompaniesComponent,
  ],
  templateUrl: './companies-page.component.html',
  styleUrl: './companies-page.component.css',
})
export class CompaniesPageComponent {}
