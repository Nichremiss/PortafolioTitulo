﻿$(document).ready(function () {

    cargarHome();

});

function cargarHome() {

    var source =
    {
        dataType: "json",
        dataFields: [
            { name: 'ShipCountry', type: 'string' },
            { name: 'ShipCity', type: 'string' },
            { name: 'ShipAddress', type: 'string' },
            { name: 'ShipName', type: 'string' },
            { name: 'Freight', type: 'number' },
            { name: 'ShippedDate', type: 'date' }
        ],
        root: 'value',
        url: "http://services.odata.org/V3/Northwind/Northwind.svc/Orders?$format=json&$callback=?"
    };
    console.log(source);

    var filterChanged = false;
    var dataAdapter = new $.jqx.dataAdapter(source,
        {
            formatData: function (data) {
                if (data.sortdatafield && data.sortorder) {
                    // update the $orderby param of the OData service.
                    // data.sortdatafield - the column's datafield value(ShipCountry, ShipCity, etc.).
                    // data.sortorder - the sort order(asc or desc).
                    data.$orderby = data.sortdatafield + " " + data.sortorder;
                }
                if (data.filterslength) {
                    filterChanged = true;
                    var filterParam = "";
                    for (var i = 0; i < data.filterslength; i++) {
                        // filter's value.
                        var filterValue = data["filtervalue" + i];
                        // filter's condition. For the filterMode="simple" it is "CONTAINS".
                        var filterCondition = data["filtercondition" + i];
                        // filter's data field - the filter column's datafield value.
                        var filterDataField = data["filterdatafield" + i];
                        // "and" or "or" depending on the filter expressions. When the filterMode="simple", the value is "or".
                        var filterOperator = data[filterDataField + "operator"];

                        var startIndex = 0;
                        if (filterValue.indexOf('-') == -1) {
                            if (filterCondition == "CONTAINS") {
                                filterParam += "substringof('" + filterValue + "', " + filterDataField + ") eq true";
                                filterParam += " " + filterOperator + " ";
                            }
                        }
                        else {
                            if (filterDataField == "ShippedDate") {
                                var dateGroups = new Array();
                                var startIndex = 0;
                                var item = filterValue.substring(startIndex).indexOf('-');
                                while (item > -1) {
                                    dateGroups.push(filterValue.substring(startIndex, item + startIndex));
                                    startIndex += item + 1;
                                    item = filterValue.substring(startIndex).indexOf('-');
                                    if (item == -1) {
                                        dateGroups.push(filterValue.substring(startIndex));
                                    }
                                }
                                if (dateGroups.length == 3) {
                                    filterParam += "year(ShippedDate) eq " + parseInt(dateGroups[0]) + " and month(ShippedDate) eq " + parseInt(dateGroups[1]) + " and day(ShippedDate) eq " + parseInt(dateGroups[2]);
                                }
                                filterParam += " " + filterOperator + " ";
                            }
                        }
                    }
                    // remove last filter operator.
                    filterParam = filterParam.substring(0, filterParam.length - filterOperator.length - 2);

                    data.$filter = filterParam;
                    source.totalRecords = 0;
                }
                else {
                    if (filterChanged) {
                        source.totalRecords = 0;
                        filterChanged = false;
                    }
                }

                if (source.totalRecords) {
                    // update the $skip and $top params of the OData service.
                    // data.pagenum - page number starting from 0.
                    // data.pagesize - page size
                    data.$skip = data.pagenum * data.pagesize;
                    data.$top = data.pagesize;
                }
                return data;
            },
            downloadComplete: function (data, status, xhr) {
                if (!source.totalRecords) {
                    source.totalRecords = data.value.length;
                }
            },
            loadError: function (xhr, status, error) {
                throw new Error("http://services.odata.org: " + error.toString());
            }
        }
    );

    $("#dataTable").jqxDataTable(
    {
        width: 850,
        pageable: true,
        pagerButtonsCount: 10,
        serverProcessing: true,
        source: dataAdapter,
        altRows: true,
        filterable: true,
        filterMode: 'simple',
        sortable: true,
        columnsResize: true,
        columns: [
            { text: 'Ship Name', dataField: 'ShipName', width: 300 },
            { text: 'Ship Country', dataField: 'ShipCountry', width: 300 },
            { text: 'Ship City', dataField: 'ShipCity', width: 200 },
            { text: 'Ship Address', dataField: 'ShipAddress', width: 200 },
            { text: 'Ship Date', dataField: 'ShippedDate', width: 200, cellsFormat: 'yyyy-MM-dd' }
        ]
    });
}