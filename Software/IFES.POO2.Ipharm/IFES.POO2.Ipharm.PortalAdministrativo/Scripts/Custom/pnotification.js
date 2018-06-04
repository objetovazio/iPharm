$("form").bind('invalid-form.validate',
    function (form, validator) {
        var errors = "";
        for (var i = 0; i < validator.errorList.length; i++) {
            errors += validator.errorList[i].message + " \n";
        }
        if (errors != "") MessageError("Erro", errors);
    }
);

function MessageNotice(title, text) {
    new PNotify({
        title: title,
        text: text
    });
}

function MessageInfo(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'info'
    });
}

function MessageSuccess(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'success'
    });
}

function MessageError(title, text) {
    new PNotify({
        title: title,
        text: text,
        type: 'error'
    });
}
