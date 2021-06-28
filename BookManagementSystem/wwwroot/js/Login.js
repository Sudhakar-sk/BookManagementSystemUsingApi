$(function () {

    $("#formDetails").validate({
        rules:
        {
            Username: {
                required: true,
                maxlength: 50

            },

            Password: {
                required: true,
                minlength: 4,
                maxlength: 8
            }


        },
        messages:
        {
            Username: {
                required: "Name is required",
                maxlegth: "Maximum length 50 only"
            },
            Password:
            {
                required: "Password is required",
                minlength: "Password should have miminum of 4 characters",
                maxlength: "Password should not over 8 characters"
            }
        }
    });
});

function SubmitDetails() {
    if ($("#formDetails").valid()) {
        $("#formDetails").submit();
    }
}