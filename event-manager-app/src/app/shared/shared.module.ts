import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrucateDirective } from './truncate.diretive';
import { HighlightDirective } from './highlight.directive';
import { EventFilterPipe } from './event-filter.pipe';


@NgModule({
  declarations: [TrucateDirective, HighlightDirective, EventFilterPipe],
  imports: [
    CommonModule
  ],
  exports: [TrucateDirective, HighlightDirective, EventFilterPipe]
})
export class SharedModule { }
