$(function () {
    jQuery("#grid-user").jqGrid({
        url: 'DataProviderForTable',
        datatype: "json",
        height: 'auto',
        rowNum: 30,
        colNames: ['Id', 'Username', 'CourseName', 'DueDate', 'DateOfAssignment', 'Type', 'State'],
        jsonReader: {
            root: 'rows',
            id: 'Id',
            repeatitems: false,
            page: 'page',
            total: 'total',
            records: 'records',
        },
        colModel: [
            { name: 'Id', index: 'Id', key: true },
            { name: 'Username', index: 'Username', width: 90, sorttype: "string", formatter: "string" },
            { name: 'CourseName', index: 'CourseName', width: 100, editable: true },
            { name: 'DueDate', index: 'DueDate', width: 80, align: "right", sorttype: "float", formatter: "number", editable: true },
            { name: 'DateOfAssignment', index: 'DateOfAssignment', width: 80, align: "right", sorttype: "float", editable: true },
            { name: 'Type', index: 'Type', width: 80, align: "right", sorttype: "float", editable: true },
            { name: 'State', index: 'State', width: 150, sortable: false }
        ],
        pager: "#plist485",
        viewrecords: true,
        sortname: 'Username',
        grouping: true,
        groupingView: {
            groupField: ['Username'],
            groupColumnShow: [false],
            groupText: ['<b>{0} - {1} Item(s)</b>'],
            groupCollapse: true,
            groupOrder: ['desc']
        },
        caption: "Initially hidden data"
    });
});


