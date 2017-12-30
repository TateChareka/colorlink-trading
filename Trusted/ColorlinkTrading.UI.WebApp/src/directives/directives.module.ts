import { NgModule } from '@angular/core';
import { WidthCheckDirective } from './width-check';
import { SdPointerDirective } from './sd-pointer';


@NgModule({
	declarations: [
		WidthCheckDirective,
		SdPointerDirective
	],
	imports: [],
	exports: [
		WidthCheckDirective,
		SdPointerDirective
	]
})
export class DirectivesModule { }
