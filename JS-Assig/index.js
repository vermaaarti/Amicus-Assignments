
var globalArray = [];

$(document).ready(function() {
  // Initialize DataTable
 // var dataTable = $('#dataTable').DataTable();
  let dataTable = new DataTable('#dataTable');

  $("#submitButton").click(function(event) {
    event.preventDefault(); // Prevent the default button behavior

    var formDataObject = {};
    $("#myForm .dataToAdd").each(function() {
      formDataObject[$(this).attr("name")] = $(this).val();
    });

    globalArray.push(formDataObject);
    console.log(formDataObject);
    //console.log(globalArray);


    // when we want to clear the table record each time
   // Clear existing rows and populate the DataTable with new data
    dataTable.clear();
    globalArray.forEach(function(data) {
      dataTable.row.add([data.id, data.name, data.department, data.shift]);
    });
    dataTable.draw();


  // when we don't want to clear the table-data each time 
  // Add the new form data directly to the DataTable
  // dataTable.row.add([formDataObject.id, formDataObject.name,
  //    formDataObject.department, formDataObject.shift]).draw();
     

  });
});










