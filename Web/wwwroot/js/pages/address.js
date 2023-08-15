var $Address = function () {

    return {
        save: function saveRecord() {
            var form = $("#createAddress");
            exn.callJx(form.attr("action"), "body", form.serialize());

        }
    }
}();

$().ready(function () {
});