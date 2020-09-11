import { Injectable } from '@angular/core';
import { EVENTS } from './mock/mock-events.data';
import { EventModel } from '../models/event.model';

@Injectable({
    providedIn: 'root'
})
export class EventService {
    private data: EventModel[];

    constructor(){
        if(localStorage.getItem('events') != null && localStorage.getItem('events') != undefined){
            this.data = JSON.parse(localStorage.getItem('events'));
        }else{
            this.data = EVENTS;
            localStorage.setItem('events', JSON.stringify(EVENTS));
        }
    }
    public getEvents(): EventModel[] {
        return this.data;
    }

    public addEvent(eventModel: EventModel) {
        eventModel.eventId = this.data.length +1;
        this.data.push(eventModel);
        localStorage.setItem('events', JSON.stringify(this.data));
    }
}