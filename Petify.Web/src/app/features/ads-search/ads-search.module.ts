import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdsSearchRoutingModule } from './ads-search-routing.module';
import { AdsSearchComponent } from './ads-search/ads-search.component';
import { AdsFilterComponent } from './ads-search/ads-filter/ads-filter.component';
import { AdoptionTabComponent } from './ads-search/adoption-tab/adoption-tab.component';


@NgModule({
  declarations: [
    AdsSearchComponent,
    AdsFilterComponent,
    AdoptionTabComponent
  ],
  imports: [
    CommonModule,
    AdsSearchRoutingModule
  ]
})
export class AdsSearchModule { }
