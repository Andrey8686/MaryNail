$(function($) {
    tinyMCE.init({
        selector: ".tinymce",
        language_url: "/Scripts/tinymce/langs/ru.js",
        plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools wordcount",

            "hr textcolor"
        ],


        toolbar1: "undo redo | bold italic underline strikethrough subscript superscript | forecolor backcolor | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | link image | hr removeformat"
    });
});