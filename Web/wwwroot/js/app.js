var app = function () {
    return {
        hideMask: function (block) {
            if (block) {
                $(block).unblock();
            }
            else {
                $.unblockUI();
            }
        },
        showMask: function (block, msg) {
            var maskOptions = {
                message: '<i class="fa fa-2x fa-spinner fa-spin"></i>' + (msg !== undefined ? msg : ""),
                overlayCSS: {
                    backgroundColor: 'rgba(255, 255, 255, 0.8)',
                    cursor: 'wait',
                    'box-shadow': '0 0 0 1px #ddd'
                },
                css: {
                    border: 0,
                    padding: 0,
                    backgroundColor: 'transparent'
                }
            };

            if (block) {
                $(block).block(maskOptions);
            } else {
                $.blockUI(maskOptions);
            }
        },
        gotoUrl: function (url) {
            app.showMask("body", "Yönlendiriliyorsunuz. Lütfen bekleyiniz...");
            window.location.href = url;
        },
        callJx: function (url, mask, data, done, fail) {
            app.showMask(mask);

            var jx = $.ajax({
                type: 'POST',
                url: url,
                data: data,
                cache: false,
                success: function (result) {
                    debugger;
                    if (result.data.success) {
                        app.hideMask(mask);

                        if (result.redirect) {
                            toastr.success(result.data.message, 'İşlem Başarılı', { timeOut: 5000 });
                            app.gotoUrl(result.redirect);
                            return;
                        }
                    } else {
                        app.hideMask(mask);
                        if (result.data.errors != null) {
                            $.each(result.data.errors, function (i, e) {
                                toastr.error(e.errorMessage, e.message, { timeOut: 5000 });
                            });
                        } else {
                            debugger;
                            toastr.warning(result.data.message, 'Uyarı', { timeOut: 5000 });
                        }
                    }
                    if (done && typeof done === 'function') {
                        debugger;
                        done.call(undefined, result);
                    }
                    //    app.ajaxDone();
                },
                error: function (xhr, status, error) {
                    debugger;
                    app.hideMask(mask);
                    if (fail && typeof fail === 'function') {
                        fail.call(undefined);
                    }
                    else {
                        debugger;
                        if (status != "abort") {
                            toastr.error("Beklenmedik bir hata oluştu", 'Hata', { timeOut: 5000 });
                        }
                    }
                }
            });
            return jx;
        },
        getJx: function (url, mask, data, done, fail) {
            debugger;
            app.showMask(mask);

            var jx = $.ajax({
                type: 'GET',
                url: url,
                data: data,
                cache: false,
                success: function (result) {
                    app.hideMask(mask);

                    if (result && typeof result === 'object') {
                        if (result.redirect) {
                            app.gotoUrl(result.redirect);
                            return;
                        }

                        if (result.hasError !== undefined) {
                            if (result.hasError) {
                                if (result.errors && result.errors.length) {
                                    app.showModal("danger", "Hata", app.resultError(result));
                                }
                                return;
                            }
                        }
                    }

                    if (done && typeof done === 'function') {
                        done.call(undefined, result.data.data);
                    }
                    app.ajaxDone();
                },
                error: function (xhr, status, error) {
                    app.hideMask(mask);
                    if (fail && typeof fail === 'function') {
                        fail.call(undefined);
                    }
                    else {
                        app.showModal("danger", "Hata", "Beklenmedik bir hata oluştu");
                    }
                }
            });

            return jx;
        },
        resultError: function (result) {
            if (!result.errors) {
                return "Beklenmedik bir hata oluştu";
            }
            return result.errors.join("<br />");
        },
        confirmModal: function (title, message, callback) {
            var modal = $('<div class="modal fade" tabindex="-1" role="dialog">');
            var modalDialog = $('<div class="modal-dialog" role="document">');
            var modalContent = $('<div class="modal-content">');
            var modalHeader = $('<div class="modal-header">');
            var modalTitle = $('<h5 class="modal-title">').html(title);
            var closeButton = $('<button type="button" class="close" data-dismiss="modal" aria-label="Close">')
                .html('<span aria-hidden="true">&times;</span>');
            var modalBody = $('<div class="modal-body">').html(message);
            var modalFooter = $('<div class="modal-footer">');
            var confirmButton = $('<button type="button" class="btn btn-primary">').text('Evet');
            var cancelButton = $('<button type="button" class="btn btn-default" data-dismiss="modal">').text('Hayır');

            confirmButton.click(function () {
                modal.modal('hide');
                callback();
            });

            modalHeader.append(modalTitle, closeButton);
            modalFooter.append(confirmButton, cancelButton);
            modalContent.append(modalHeader, modalBody, modalFooter);
            modalDialog.append(modalContent);
            modal.append(modalDialog);

            $('body').append(modal);
            modal.modal('show');
        },
        showErrorDialog: function (title, message, href) {
            var modal = $('<div class="modal fade" tabindex="-1" role="dialog">');
            var modalDialog = $('<div class="modal-dialog" role="document">');
            var modalContent = $('<div class="modal-content">');
            var modalHeader = $('<div class="modal-header error">');
            var modalTitle = $('<h5 class="modal-title">').html(title);
            var closeButton = $('<button type="button" class="close" data-dismiss="modal" aria-label="Close">')
                .html('<span aria-hidden="true">&times;</span>');
            var modalBody = $('<div class="modal-body">').html(message);
            var modalFooter = $('<div class="modal-footer">');
            var okButton = $('<button type="button" class="btn btn-primary">').text('Tamam');

            modalHeader.append(modalTitle, closeButton);
            modalFooter.append(okButton);
            modalContent.append(modalHeader, modalBody, modalFooter);
            modalDialog.append(modalContent);
            modal.append(modalDialog);


            okButton.click(function () {
                if (href) {
                    window.location.href = href;
                }
                modal.modal('hide');
            });

            modal.on('click', function (e) {
                if (e.target === modal[0]) {
                    if (href) {
                        window.location.href = href;
                    }
                    modal.modal('hide');
                }
            });

            $('body').append(modal);
            modal.modal('show');
        },

    };
}();








