/// <reference path="loansky.js" />
/// <reference path="../lib/kendo/2018.3.1017//js/kendo.all.min.js" />

loansky.kendo = new function () {
    function defaultError(e) {
        var response = e.xhr.responseJSON;
        if (response) {
            if (response.ErrorMessage)
                alert(response.ErrorMessage);
            else if (response.ExceptionMessage)
                alert(response.ExceptionMessage);
            else if (response.Message)
                alert(response.Message);
        }
        else if (e.status && e.errorThrown) {
            alert(e.status + ':' + e.errorThrown);
        }

        e.sender.fetch();
    }

    function timeEditor(container, options) {
        $('<input data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '" data-format="' + options.format + '"/>')
            .appendTo(container)
            .kendoTimePicker({});
    }

    function dateTimeEditor(container, options) {
        $('<input data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '" data-format="' + options.format + '"/>')
            .appendTo(container)
            .kendoDateTimePicker({});
    }

    function yearMonthEditor(container, options) {
        $('<input data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '" data-format="' + options.format + '"/>')
            .appendTo(container)
            .kendoDatePicker({});
    }

    function litigationGroupEditor(container, options) {
        $('<input name="LitigationGroup" id="LitigationGroup" required data-text-field="Value" data-value-field="Key" data-bind="value:' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                placeholder: "請選擇書狀分類",
                filter: "startswith",
                dataSource: {
                    serverFiltering: true,
                    transport: {
                        read: {
                            url: '/Writ/ReadLitigationGroups',
                            dataType: 'json',
                            type: 'POST'
                        }
                    }
                }
            });
    }

    function litigationTypeEditor(container, options) {
        $('<input name="LitigationType" id="LitigationType" required data-text-field="Name" data-value-field="Id" data-bind="value:' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                filter: "startswith",
                autoBind: false,
                placeholder: "請選擇書狀種類",
                cascadeFrom: 'LitigationGroup',
                dataSource: {
                    serverFiltering: true,
                    transport: {
                        read: {
                            url: '/Writ/ReadLitigationTypes',
                            dataType: 'json',
                            type: 'POST'
                        }
                    }
                }
            });
    }

    function setGridEdit4DropDownListCascade(e) {
        var viewModel = e.model;
        if (!viewModel.isNew()) {
            var litigationGroup = e.container.find("input[name=LitigationGroup]").data("kendoDropDownList");
            litigationGroup.open();
            litigationGroup.toggle();
            //litigationType = e.container.find("input[name=LitigationType]").data("kendoDropDownList");
        }
    }

    return {
        defaultError: function (e) {
            defaultError(e);
        },
        timeEditor: function (container, options) {
            timeEditor(container, options);
        },
        dateTimeEditor: function (container, options) {
            dateTimeEditor(container, options);
        },
        yearMonthEditor: function (container, options) {
            yearMonthEditor(container, options);
        },
        litigationGroupEditor: function (container, options) {
            litigationGroupEditor(container, options);
        },
        litigationTypeEditor: function (container, options) {
            litigationTypeEditor(container, options);
        },
        setGridEdit4DropDownListCascade: function (e) {
            setGridEdit4DropDownListCascade(e);
        }
    };
};