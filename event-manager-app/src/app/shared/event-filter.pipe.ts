import { Pipe, PipeTransform } from '@angular/core';
import { EventModel } from '../models/event.model';

@Pipe({
    name: 'eventFilter',
    pure: true
})
export class EventFilterPipe implements PipeTransform {
    transform(items: EventModel[], arg: string){
      
      if(arg === null || arg === undefined){
          return items;
      }

      const filteredItems = items.filter(item => item.Title.toLocaleLowerCase().indexOf(arg.toLocaleLowerCase()) !== -1);
      return filteredItems;
    }
}