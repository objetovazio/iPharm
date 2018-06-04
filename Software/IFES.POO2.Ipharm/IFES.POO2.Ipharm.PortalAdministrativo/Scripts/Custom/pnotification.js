$("form").bind('invalid-form.validate',
    function (form, validator) {
        var errors = "";
        for (var i = 0; i < validator.errorList.length; i++) {
            errors += validator.errorList[i].message + " \n";
        }
        if (errors != "") MessageError("Erro", errors);
    }
);

PNotify.prototype.options.delay ? (function () {
    PNotify.prototype.options.delay -= 6000;
    update_timer_display();
}()) : (alert('Timer is already at zero.'))

function MessageNotice(title, text) {
    new PNotify({
        title: title,
        text: text,
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
        animate: {
            animate: true,
            in_class: 'bounceInLeft',
            out_class: 'bounceOutRight'
        }
    });
}
