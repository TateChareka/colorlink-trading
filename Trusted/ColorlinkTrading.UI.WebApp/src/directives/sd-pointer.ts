import { Directive, ElementRef, Renderer } from '@angular/core';


@Directive({
  selector: '[sd-pointer]' // Attribute selector
})
export class SdPointerDirective {

  constructor(public el: ElementRef, public renderer: Renderer) {
    this.renderer.setElementStyle(el.nativeElement, 'cursor', 'pointer');
  }

}
