var $Product = function () {

    return {
        //init: function () {
        //    debugger;
        // $Product.datas();
        //},
        datas: function () {
            var tableGlobalFiter = {
                First: 2,
                Rows: 3,
                SortField: null,
                SearchText: null,
                PropertyField: []
            };
            exn.getJx('/Products/Read', 'body', tableGlobalFiter, function (data) {
                debugger;
                var data = data;
                var table = '<table class="table"><thead><tr><th>Name</th><th>Marka</th><th>Kategori</th><th>Kod</th><th>Birim Fiyat</th></tr></thead><tbody>';
                $.each(data, function (i, item) {
                    debugger;
                    table += '<tr><td>' + item.name + '</td><td>' + item.categoryName + '</td><td>' + item.brandName + '</td><td>' + item.code + '</td><td>' + item.unitPrice + '</td></tr>';
                });
                table += '</tbody></table>';
                $('#table-container').html(table);
            });
            //$.ajax({
            //    url: '/Products/Read',
            //    type: 'GET',
            //    dataType: 'json',
            //    success: function (result) {
            //        var data = result.data.data;
            //        debugger;
            //        var table = '<table class="table"><thead><tr><th>Name</th><th>Marka</th><th>Kategori</th><th>Kod</th><th>Birim Fiyat</th></tr></thead><tbody>';
            //        $.each(data, function (i, item) {
            //            debugger;
            //            table += '<tr><td>' + item.name + '</td><td>' + item.categoryName + '</td><td>' + item.brandName + '</td><td>' + item.code + '</td><td>' + item.unitPrice + '</td></tr>';
            //        });
            //        table += '</tbody></table>';
            //        $('#table-container').html(table);
            //    }
            //});
        },
        save: function saveRecord() {
            var form = $("#createProduct");
            app.callJx(form.attr("action"), "body", form.serialize());

        }
    }
}();

$().ready(function () {
//    $Product.datas();
});