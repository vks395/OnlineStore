
$(document).ready(() => {
    $("#previewdiv").hide();
    $('#file').change(function () {
        const file = this.files[0];
        console.log(file);
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                console.log(event.target.result);
                $('#imgPreview').attr('src', event.target.result);
            }
            $("#previewdiv").show();
            reader.readAsDataURL(file);
        }
    });
});
$(document).on('keydown keyup', '.decimalinput', function (el) {
    var ex = /^[0-9]*\.?[0-9]*$/;
    if (ex.test(el.target.value) === false) {
        el.target.value = el.target.value.substring(0, el.target.value.length - 1);
    }
});
