$("form").bind('invalid-form.validate',
    function (form, validator) {
        var errors = "";
        for (var i = 0; i < validator.errorList.length; i++) {
            errors += validator.errorList[i].message + " \n";
        }
        if (errors != "") MessageError("Erro", errors);
    }
);

PNotify.prototype.options.delay
    ? (function() {
        PNotify.prototype.options.delay -= 6000;
        //update_timer_display();
    }())
    : (alert('Timer is already at zero.'));

function MessageNotice(title, text) {
    new PNotify({
        title: title,
        text: text,
        nonblock: {
            nonblock: true
        },
        buttons: {
            show_on_nonblock: true
        },
        animate: {
            animate: true,
            in_class: 'bounceInLeft',
            out_class: 'bounceOutRight'
        }
    });
}

function MessageInfo(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'info',
        icon: 'fa fa-info',
        nonblock: {
            nonblock: true
        },
        buttons: {
            show_on_nonblock: true
        },
        animate: {
            animate: true,
            in_class: 'bounceInLeft',
            out_class: 'bounceOutRight'
        }
    });
}

function MessageSuccess(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'success',
        icon: 'fa fa-check-circle',
        nonblock: {
            nonblock: true
        },
        buttons: {
            show_on_nonblock: true
        },
        animate: {
            animate: true,
            in_class: 'bounceInLeft',
            out_class: 'bounceOutRight'
        }
    });
}

function MessageError(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'error',
        icon: 'fa fa-times-circle',
        nonblock: {
            nonblock: true
        },
        buttons: {
            show_on_nonblock: true
        },
        animate: {
            animate: true,
            in_class: 'bounceInLeft',
            out_class: 'bounceOutRight'
        }
    });
}

function Message(messageType, text) {
    if (messageType === '1') MessageSuccess("Sucesso", text);
    if (messageType === '2') MessageError("Error", text);
    if (messageType === '3') MessageInfo("Info", text);
    if (messageType === '4') MessageNotice("Aviso", text);
}