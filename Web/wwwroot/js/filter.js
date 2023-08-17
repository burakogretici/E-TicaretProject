///$(document).ready(function () {
////    debugger;
////    fetchDataAndProcessTable();
////});

//$(document).on('click', '#searchButton', function () {
//    debugger;
//    fetchDataAndProcessTable();
//});

//function fetchDataAndProcessTable() {
//    debugger;
//    var searchFilters = [];

//    $('.filter').each(function () {
//        var filter = {};

//        filter.Field = $(this).find('.filter-field').val();
//        filter.Operator = $(this).find('.filter-operator').val();
//        filter.Value = $(this).find('.filter-value').val();

//        searchFilters.push(filter);
//    });

//    var tableGlobalFilter = {
//        First: 1,
//        Rows: 5,
//        SortField: null,
//        SortOrder: null,
//        SearchFilters: searchFilters
//    };

//    if ($("thead > tr > th.sorting_asc").length) {
//        tableGlobalFilter.SortField = $("thead > tr > th.sorting_asc").attr("field");
//        tableGlobalFilter.SortOrder = $("thead > tr > th.sorting_asc").attr("order");
//    } else if ($("thead > tr > th.sorting_desc").length) {
//        tableGlobalFilter.SortField = $("thead > tr > th.sorting_desc").attr("field");
//        tableGlobalFilter.SortOrder = $("thead > tr > th.sorting_desc").attr("order");
//    }

//    var table = $('.table');
//    var readUrl = table.attr('read-url');
//    var page = table.attr('page');
//    var pageSize = table.attr('page-size');

//    if (page) {
//        tableGlobalFilter.First = parseInt(page);
//    }
//    if (pageSize) {
//        tableGlobalFilter.Rows = parseInt(pageSize);
//    }

//    $.ajax({
//        url: readUrl,
//        type: 'POST',
//        data: JSON.stringify(tableGlobalFilter),
//        contentType: 'application/json',
//        success: function (data) {
//            processTableData(data);
//        }
//    });
//}

////function processTableData(data) {
////    debugger;
////    // Tablo verilerini iþleme iþlemleri
////    // ...
////}
