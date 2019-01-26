$.fn.UploadFiles = function(event) {
    var main = $(this);
    var idTimeout;

    $(window).bind("dragover",
        function(e) {
            e.stopPropagation();
            e.preventDefault();
            main.addClass("active");
            clearTimeout(idTimeout);
            idTimeout = setTimeout(function() {
                    main.removeClass("active");
                },
                100);
        });

    main.find(".ub-file").on("change",
        function(e) {
            e.preventDefault();
            uploadFile(this.files);
        });

    $(this).on("drop",
        function(e) {
            e.preventDefault();
            uploadFile(e.originalEvent.dataTransfer.files);
        });

    function uploadFile(files) {
        if (files.length === 0) return false;

        var fd = new FormData();
        for (var x = 0; x < files.length; x++) {
            fd.append("file" + x, files[x]);
        }


        for (var k in event.json) {
            if (event.json[k] == null) continue;
            fd.append(k, event.json[k]);
        }

        $.ajax({
            type: "POST",
            url: event.url,
            contentType: false,
            processData: false,
            data: fd,
            success: function(data) {
                main.parent().html(data);
            },
            error: function(xhr, status, p3) {
            }
        });
    }

    function deleteFile(id) {

    }
};




function SendPostRequest(url, updateTarget, option = {}, c = "") {
    if (c.length) {
        if (!confirm(c)) return false;
    }
    $.post(url,
        option,
        function(data) {
            $(updateTarget).html(data);
        });
    return false;
}








function ShowError(string) {
    if (string.length) alert(string);
}


