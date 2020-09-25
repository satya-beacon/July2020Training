import { EventModel } from '../../models/event.model';

export const EVENTS: EventModel[] = [ 
    {eventId: 100, Title: 'Angular 10', shortDescription: 'Angular 10 for SPA', 
    longDescription: 'JavaScript MVC framework for SPA', publishedDate: new Date(), isPublished: false, dateCreated: new Date()},
    {eventId: 101, Title: 'JavaScript', shortDescription: 'JavaScript language', 
    longDescription: 'JavaScript MVC framework for SPA', publishedDate: new Date(), isPublished: false, dateCreated: new Date()},
    {eventId: 102, Title: '.NET Core', shortDescription: '.net Backend', 
    longDescription: 'JavaScript MVC framework for SPA', publishedDate: new Date(), isPublished: false, dateCreated: new Date()},
    {eventId: 103, Title: 'SQL', shortDescription: 'Relational database', 
    longDescription: 'JavaScript MVC framework for SPA', publishedDate: new Date(), isPublished: false, dateCreated: new Date()}
];