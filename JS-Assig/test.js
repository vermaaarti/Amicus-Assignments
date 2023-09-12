
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
  
 // var arrToStoreShift = [];
  $("#submitButton").click(function(event) {
    event.preventDefault();

    var formDataObject = {};

    $("#myForm .dataToAdd").each(function() {
      var header = $(this).attr("name");
      formDataObject[header] = $(this).val();

   });  
 
   // .has()
  
   if(noBlankField(formDataObject) == true){
    if(globalArray.length == 0 || (idExist(formDataObject)==false)){
      globalArray.push(formDataObject);
     }
    }
    else {
      alert("some data fields are blank"); 
  }
 
   
    // Clear the DataTable
    dataTable.clear();

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
  
   //-----------------------------------------------------------------------------------------------
   //---------------------------------code to check for the duplicate ID-------------------
  $("#onSubmit").click(function(event) {
    event.preventDefault();

    var inputData = $("#exampleFormControlSelectoption").val();
  
    //var filteredData;

    var filteredDepartment = globalArray.filter(item => item.department === inputData)
   
   //console.log(filteredDepartment);

    if(filteredDepartment.length == 0){
        alert("no data found");
        dataTable.clear();    
         dataTable.draw();
    }   
    else{
        dataTable.clear();

    // Add each row to the DataTable
    filteredDepartment.forEach(function(data) {
      dataTable.row.add(data);
    });
    dataTable.draw();
    }

// reset the input field to null
    clearForm();
  }); 


//------------------------------------------------------------------------------------upto here


//     $("#onShiftSubmit").click(function(event) {
//       event.preventDefault();
  
            
//       var inputData = $("#Select1").val();
//      // console.log( $("#Select1").val())
//       //console.log(globalArray);
//       globalArray = globalArray.map(item=> {
//         if (item.shift === inputData) {
//           item.shift = $("#Select2").val();
//         }
//         return item;
//       });
//     // });
//          //dataTable.clear();

//   // Add each row to the DataTable
// // globalArray.forEach(function(data) {
// //     dataTable.row.add(data);
// //   });
//   dataTable.draw();
  
//     });




    $("#onShiftSubmit").click(function(event) {
      event.preventDefault();
    
      var inputData = $("#Select1").val();
        
      globalArray = globalArray.map(function(item) {
        if (item.shift == inputData) {
          item.shift = $("#Select2").val();
        }
        return item;
      });
     
      dataTable.clear();
      globalArray.forEach(function(data) {
        dataTable.row.add(data);
      });
      dataTable.draw();
    });
    

    
}); // -----------------------------------------------document.ready closing here----------------


function clearForm(){
  $('.dataToAdd').val('');
}
function noBlankField(formDataObject){

// if((formDataObject.id == '') || (formDataObject.name == '')
//  || (formDataObject.department == null) || (formDataObject.shift == null)){return false;}
//  else{return true;}

var flag1 = false;
var flag2 = false;
$("#myForm .dataToAdd").each(function() {
  let control = $(this);

  if(control.attr('type') == 'text'){
 
     if(control[0].value== ''){
 
       flag1=true;

     }
 
  }
   if(control.attr('type') == 'select'){

      if(control[0].value =='' || control[0].value ==null){

    flag2 = true;
 
  }
    }  
})
if(flag1==false && flag2==false){return true;}
  else{return false;}
 }

 function idExist(formDataObject){
    
  if(globalArray.find(item=>parseInt(item.id)===parseInt(formDataObject.id))){
    alert("ID already exists"); return true; }
 else { return false; }
}