var $Address = function () {

    return {
        save: function saveRecord() {
            var form = $("#createAddress");
            app.callJx(form.attr("action"), "body", form.serialize());

        }
    }
}();

$().ready(function () {
});