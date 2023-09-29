// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var show;
$("#SubmitBtn").click(function (event) {
    event.preventDefault();
    show = $('#textInput').val();
   // console.log(show);


    window.location.href = "Home/ViewEmployeeInfo/" + show;


});