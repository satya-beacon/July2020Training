import { Component, OnInit } from '@angular/core';
import { EventService } from '../event.service';
import { EventModel } from '../../models/event.model';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: EventModel[];
  tempEvents: EventModel[];
  searchString: string;
  
  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.events = this.eventService.getEvents();
    this.tempEvents= [...this.events];
  }

  trackByFunction(index: number, item: EventModel) : number {
    return item.eventId;
  }
}
