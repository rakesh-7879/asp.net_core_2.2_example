// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $(".state").change(function () {
        $.ajax({
            async: false,
            url: '/employee/getcity?id=' + $(this).val(),
            success: function (result) {
                var data = JSON.parse(result);
                var options = "<option value=''> -- City --</option>";
                for (var i = 0; i < data.length; i++) {
                    options += "<option value='" + data[i].CityId + "'>" + data[i].CityName + "</option>";
                }
                $(".city").html(options);
            },
            error: function (request, error) {
                console.log(arguments);
                alert(" Can't do because: " + error);
            }
        });
    });
    $(".mobile").inputmask({ "mask": "(999) 999 9999" });
    $(".zip").inputmask({ "mask": "99 9999" });

    $('.from').datepicker({
        autoclose: true,
        minViewMode: 1,
        format: 'MM/yyyy'
    }).on('changeDate', function (selected) {
        startDate = new Date(selected.date.valueOf());
        startDate.setDate(startDate.getDate(new Date(selected.date.valueOf()))+31);
        $('.to').datepicker('setStartDate', startDate);
    });

    $('.to').datepicker({
        autoclose: true,
        minViewMode: 1,
        format: 'MM/yyyy'
    }).on('changeDate', function (selected) {
        FromEndDate = new Date(selected.date.valueOf());
        FromEndDate.setDate(FromEndDate.getDate(new Date(selected.date.valueOf())));
        $('.from').datepicker('setEndMonth', FromEndDate);
    });

    $(function () {
        $(".datepickerDOB").datepicker({
            format: 'mm/dd/yyyy',
            autoclose: true,
            startDate: new Date("01/01/1980"),
            endDate: '-18y'
        });
        $(".datepicker").datepicker({
            format: 'mm/dd/yyyy',
            autoclose: true,
            todayHighlight: true
        });
    });

    $('.joiningdatepicker').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy',
        startDate: '+1d'
    }).on('changeDate', function (selected) {
        startDate = new Date(selected.date.valueOf());
        startDate.setDate(startDate.getDate(new Date(selected.date.valueOf()))+1);
        $('.leavingdatepicker').datepicker('setStartDate', startDate);
    });

    $('.leavingdatepicker').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
    }).on('changeDate', function (selected) {
        FromEndDate = new Date(selected.date.valueOf());
        FromEndDate.setDate(FromEndDate.getDate(new Date(selected.date.valueOf())));
        $('.joiningdatepicker').datepicker('setEndMonth', FromEndDate);
    });

    $(".attach").click(function () {
        $(".attachitem").append("<div><input type='file'  name='files' class='m-sm-1'><i class='fa fa-trash p-sm-2 delete'></i></div>");
        $(".delete").click(function () {
            $(this).parent().remove();
        });
    });
    $(function () {
        var i = 1;
        $("td:first-child").each(function () {
            $(this).html(i++);
        }); 
    });
    $(".showdatepicker").click(function () {
        $(this.parentNode.parentNode.firstElementChild).focus();
    });
});
