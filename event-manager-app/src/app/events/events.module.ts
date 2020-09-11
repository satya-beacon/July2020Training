import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventsRoutingModule } from './events-routing.module';
import { EventListComponent } from './event-list/event-list.component';

@NgModule({
    declarations: [EventListComponent],
    imports: [
        CommonModule,
        EventsRoutingModule
    ],
    exports: [],
    providers: []
})
export class EventsModule {

}