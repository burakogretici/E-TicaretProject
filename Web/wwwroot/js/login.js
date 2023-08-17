+ function ($) {
    $('.palceholder').click(function () {
        $(this).siblings('input').focus();
    });

    $('.form-control').focus(function () {
        $(this).parent().addClass("focused");
    });

    $('.form-control').blur(function () {
        var $this = $(this);
        if ($this.val().length == 0)
            $(this).parent().addClass("focused");
    });
    $('.form-control').blur();

    $.validator.setDefaults({
        errorElement: 'span',
        errorClass: 'validate-tooltip'
    });
    

}(jQuery);