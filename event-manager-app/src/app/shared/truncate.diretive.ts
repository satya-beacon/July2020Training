import { Directive, ElementRef, AfterViewInit, Input } from '@angular/core';

@Directive({
    selector: '[truncate]'
})
export class TrucateDirective implements AfterViewInit {


    @Input('truncate') size: number = 10;
    
    constructor(private el: ElementRef) {
       
    }

    ngAfterViewInit() {
        const input = this.el.nativeElement.innerText;
        if(input !== null && input !== undefined && input.length > this.size){
            this.el.nativeElement.innerText = input.substring(0, this.size) + '...';
        }
    }
}