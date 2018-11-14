/// <reference path="../lib/jquery/dist/jquery.js" />


var loansky = function () {
    var kendoGridHeight = $(window).height() - 150;
    var kendoGridInnerHeight = 230;

    return {
        KendoGridHeight: this.kendoGridHeight,
        KendoGridInnerHeight: this.kendoGridInnerHeight
    };
};