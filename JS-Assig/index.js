// global array
var globalArray = [];

$(document).ready(function() {
 // $("#myForm").submit(function(event) {
    $("#submitButton").click(function(event) {
    event.preventDefault(); // Prevent form submission

    //  object to store form values
    var formDataObject = {};

    // Iterating through form elements 
    $(`#myForm`).find(".dataToAdd").each(function() {
      formDataObject[$(this).attr("name")] = $(this).val();
    });
    
    //console.log(formDataObject);
    globalArray.push(formDataObject);
    console.log(globalArray);
    
  });
});
// console.log(globalArray);

