import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventsRoutingModule } from './events-routing.module';
import { EventListComponent } from './event-list/event-list.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [EventListComponent],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
        EventsRoutingModule
    ],
    exports: [],
    providers: []
})
export class EventsModule {

}