// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var show;
$("#SubmitBtn").click(function () {
    show = $('#textInput').val();
   // console.log(show);



$.ajax({

    type: 'GET',

    url: '/Home/ViewEmployeeInfo',

    data: { id: show },
    success: function (data, textStatus, xhr) {
        //operation
      

    },

    error: function (errorThrown, textStatus, xhr) {
        console.log('Error in Operation', error);
    }

});

});