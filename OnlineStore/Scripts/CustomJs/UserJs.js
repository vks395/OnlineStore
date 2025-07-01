
$(document).ready(() => {
    $("#Password").attr("type", "password");
    $("#btnPassword").on("click", function () {
        $(this).toggleClass("active");
        if ($(this).hasClass("active")) {
            $(this).text("Hide Password");
            $("#Password").attr("type", "text");
        } else {
            $(this).text("Show Password");
            $("#Password").attr("type", "password");
        }
    });
    
});