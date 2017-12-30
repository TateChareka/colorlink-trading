import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser'

@Pipe({
    name: 'gridTextHighlight'
})

export class GridTextHighlightPipe implements PipeTransform {
    transform(gridCell: any, highlightText: string) {
        if (highlightText === null) {
            return gridCell.displayValue;
        }
        if (highlightText === "") {
            return gridCell.displayValue;
        }
        if (gridCell.displayValue === null) {
            return gridCell.displayValue;
        }
        if (gridCell.displayValue === "") {
            return gridCell.displayValue;
        }
        var searchMask = "(" + highlightText + ")";
        var regEx = new RegExp(searchMask, "gi");
        var replaceMask = "<span class='grid-highlight-search'>$1</span>";
        
        var res = gridCell.displayValue.replace(regEx, replaceMask);
        //var res = gridCell.displayValue;
        //res = gridCell.displayValue.replace(highlightText, "<span class='grid-highlight-search'>" + highlightText + "</span>");
        //console.log(gridCell);
        //console.log(highlightText);
        return res;
    }
}