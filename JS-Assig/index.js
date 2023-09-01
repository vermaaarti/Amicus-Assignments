var globalArray = [];

$(document).ready(function() {
  var dataTable = $('#dataTable').DataTable({
    columns: [
      { data: 'id', title: 'Id' },
      { data: 'name', title: 'Name' },
      { data: 'department', title: 'Department' },
      { data: 'shift', title: 'Shift' }
    ],
    lengthChange: false, 
    searching: false,
    info: false,        
    paging: false 
  });

  $("#submitButton").click(function(event) {
    event.preventDefault();

    var formDataObject = {};
    $("#myForm .dataToAdd").each(function() {
      var header = $(this).attr("name");
      formDataObject[header] = $(this).val();
    });

    globalArray.push(formDataObject);
    console.log(formDataObject);

    // Clear the DataTable
    dataTable.clear();

    // Add each row to the DataTable
    globalArray.forEach(function(data) {
      dataTable.row.add(data);
    });

    dataTable.draw();
  });


 

   //var newArray = [];
  $("#onSubmit").click(function(event) {
    event.preventDefault();

    var inputData = $("#exampleFormControlSelectoption").val();
  
    //var filteredData;

    var filteredDepartment = globalArray.filter(item => item.department === inputData)
   

   console.log(filteredDepartment);

    if(filteredDepartment.length == 0){
        alert("no data found");
        dataTable.clear();     dataTable.draw();
    }   
    else{
        dataTable.clear();

    // Add each row to the DataTable
    filteredDepartment.forEach(function(data) {
      dataTable.row.add(data);
    });
    dataTable.draw();
    }

  });

});











































































































//-----------------------------------------code where we are making a data table and adding the 
//array of objects in the data table with two different methods
// first where we are clearing the data of the table each time and adding the recodes 
// second where we are adding only the newly added data and tables previous records are not changed
//------------------------------------------------------------------------------------------
// var globalArray = [];

// $(document).ready(function() {
//   // Initialize DataTable
//  // var dataTable = $('#dataTable').DataTable();
//   let dataTable = new DataTable('#dataTable');

//   $("#submitButton").click(function(event) {
//     event.preventDefault(); // Prevent the default button behavior

//     var formDataObject = {};
//     $("#myForm .dataToAdd").each(function() {
//       formDataObject[$(this).attr("name")] = $(this).val();
//     });

//     globalArray.push(formDataObject);
//     console.log(formDataObject);
//     //console.log(globalArray);

//     // when we want to clear the table record each time
//    // Clear existing rows and populate the DataTable with new data
//     dataTable.clear();
//     globalArray.forEach(function(data) {
//       dataTable.row.add([data.shift, data.department, data.name,  data.id]);
//     });
//     dataTable.draw();

//   // when we don't want to clear the table-data each time 
//   // Add the new form data directly to the DataTable
//   // dataTable.row.add([formDataObject.id, formDataObject.name,
//   //    formDataObject.department, formDataObject.shift]).draw();
  
//   });
// });






//--------------------------------code where the table data is mapped to its associated header----
//-----------------------------------------------
// var globalArray = [];
// $(document).ready(function() {
//   var dataTable = $('#dataTable').DataTable({
//     columns: [
//       { data: 'id', title: 'Id' },
//       { data: 'name', title: 'Name' },
//       { data: 'department', title: 'Department' },
//       { data: 'shift', title: 'Shift' }
//     ],
//     lengthChange: false, 
//     searching: false,
//     info: false,        
//     paging: false 
//   });

//   $("#submitButton").click(function(event) {
//     event.preventDefault();

//     var formDataObject = {};
//     $("#myForm .dataToAdd").each(function() {
//       var header = $(this).attr("name");
//       formDataObject[header] = $(this).val();
//     });

//     globalArray.push(formDataObject);
//     console.log(formDataObject);

//     // Clear the DataTable
//     dataTable.clear();

//     // Add each row to the DataTable
//     globalArray.forEach(function(data) {
//       dataTable.row.add(data);
//     });

//     dataTable.draw();
//   });
// });











