import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[highlight]'
})
export class HighlightDirective {
    constructor(private el: ElementRef) {

    }
    
    @HostListener('mouseenter') onMouseOver() {
        this.el.nativeElement.style.backgroundColor = "blue";
    }


    @HostListener('mouseleave') onMouseOut() {
        this.el.nativeElement.style.backgroundColor = "cyan";
    }
}