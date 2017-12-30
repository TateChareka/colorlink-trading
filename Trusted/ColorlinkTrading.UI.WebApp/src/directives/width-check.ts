import { Directive, Input, HostListener, ElementRef } from '@angular/core';


@Directive({
  selector: '[width-check]'
})
export class WidthCheckDirective {

  /**
   * There are 2 inputs to show and hide based on device size
   * @param hideWhenWidth: the value which you want to hide/show ( 768 targets ipad and smaller )
   * @param greaterThen: Calls width to show when greater then and not smaller then which is set by default ( 769 tragets browser )
   */

  @Input() hideWhenWidth: number;
  @Input() greaterThen: boolean = false;

  constructor(private el: ElementRef) {

  }

  ngAfterViewInit() {
    this.hideShowConditional();
  }

  @HostListener('window:resize', ['$event']) onResize(event: Event) {
    this.hideShowConditional();
  }

  hideShowConditional() {
    switch (true) {
      case window.innerWidth <= this.hideWhenWidth && !this.greaterThen: this.el.nativeElement.hidden = false;
        break;
      case window.innerWidth >= this.hideWhenWidth && this.greaterThen: this.el.nativeElement.hidden = false;
        break;
      default: this.el.nativeElement.hidden = true;
        break;
    }
  }

}
