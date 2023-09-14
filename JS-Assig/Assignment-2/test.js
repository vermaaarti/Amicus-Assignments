
var globalArray = [];

$(document).ready(function() {

  var dataTable = $('#dataTable').DataTable({
    columns: [
      { data: 'country', title: 'Country' },
      { data: 'name', title: 'Name' },
      { data: 'state', title: 'State' }
    ],
    lengthChange: false, 
    searching: false,
    info: false,        
    paging: false 
  });


  $("#submitButton").click(function(event) {
    event.preventDefault();

//     var formDataObject = {};

//     $("#myForm .dataToAdd").each(function() {
//       var header = $(this).attr("name");
//       formDataObject[header] = $(this).val();

//    });  


    // Add each row to the DataTable
    globalArray.forEach(function(data) {
      dataTable.row.add(data);
    });

    dataTable.draw();

// reset the input field to null
   // document.getElementById("myForm").reset();
   // $('.dataToAdd').val('');
   clearForm();
  });
  


});