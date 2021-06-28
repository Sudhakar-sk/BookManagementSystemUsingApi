function Reset() {
    $("#BookTitle").val("");
    $("#BookAuthor").val("");
    $("#Price").val("");
}

$(function () {
    if ($("#BookId").val() == 0) {
        $("#BookTitle").val("");
        $("#BookAuthor").val("");
        $("#Price").val("");
    }
});
$(function () {

    var form = $('#formDetails').get(0);
    $.removeData(form, 'validator');
    validator = $('#formDetails').validate({
        rules:
        {
            BookTitle:
            {
                required: true,
                maxlength: 150

            },

            BookAuthor:
            {
                required: true,
                maxlength: 100,

            },
            Price:
            {
                required: true,
                maxlength: 6,
            },

        },
        messages:
        {

            BookTitle:
            {
                required: " Book Title is required",
                maxlength: " BookTitle should not over 150 character",

            },
            BookAuthor:
            {
                required: " Author Name is required",
                maxlength: " Author Name should not over 100 character",

            },
            Price:
            {
                required: "Price is required",
                maxlength: "Price should be 6 digits",
            }
        }
    });
});

function SubmitDetails()
{

    if ($("#formDetails").valid())
    {
        $("#formDetails").submit();
    }
}