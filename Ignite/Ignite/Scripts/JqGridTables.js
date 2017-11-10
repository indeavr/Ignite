function onGridLoaded() {
    jQuery("#grid-user").jqGrid({
        url: "DataProviderForTable",
        datatype: "json",
        height: 'auto',
        width: 800,
        rowNum: 30,
        rowList: [10, 20, 30],
        colNames: ['Index', 'Username', 'Course', 'AssignementDate', 'DueDate', 'State', 'Type'],
        colModel: [
            { name: 'Index', key: true, index: 'Index', width: 30, formatter: "integer", search: false },
            { name: 'Username', index: 'Username', width: 120, searchoptions: { sopt: ['eq'] } },
            { name: 'Coursename', index: 'Coursename', width: 120, align: "left", searchoptions: { sopt: ['eq'] } },
            { name: 'AssignementDate', index: 'AssignementDate', width: 70, align: "left", formatter: "date", search: false },
            { name: 'DueDate', index: 'DueDate', width: 70, align: "left", formatter: "date", search: false },
            { name: 'State', index: 'State', width: 60, align: "left", searchoptions: { sopt: ['eq'] } },
                { name: 'Type', index: 'Type', width: 60, align: "left", searchoptions: { sopt: ['eq'] } }
        ],

        jsonReader: {
            repeatitems: false,
            id: "Index",
            root: 'rows',
            records: 'records',
            page: 'page',
            total: 'total'
        },
        pager: "#plist485",
        viewrecords: true,
        sortname: 'Username',
        grouping: true,
        groupingView: {
            groupField: ['Username'],
            groupColumnShow: [true],
            groupText: ['<b>{0} - {1} Item(s)</b>'],
            groupCollapse: true,
            groupOrder: ['desc']
        },
        caption: "Information about all users"
    });
    jQuery("#grid-user").jqGrid('navGrid', 
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );
}


