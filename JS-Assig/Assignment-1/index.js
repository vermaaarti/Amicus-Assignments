
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


// if(anyBlankField(formDataObject)==true){ alert("some data fields are blank"); }
// else{


   if(anyBlankField(formDataObject) == true){
    if(globalArray.length == 0 || (idExist(formDataObject)===false)){

      globalArray.push(formDataObject);
     }
    }
  //   else {
  //     alert("some data fields are blank"); 
  // }

//});
 // }
  
  
   
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
   
   console.log(filteredDepartment);

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


 
});


function clearForm(){
  $('.dataToAdd').val('');
}
function noBlankField(formDataObject){

  // formDataObject.each(function(data) {
  //   if(data.val() == ''){return true;}
      //  });


// if((formDataObject.id == '') || (formDataObject.name == '')
//  || (formDataObject.department == null) || (formDataObject.shift == null)){return false;}
//  else{return true;}





 // const keysof = Object.keys(formDataObject);
  //for (var item in keysof) {
   // var data = formDataObject.find(item=> item.val() == '')
    //if(data){return true;} 
  
    // console.log(item,formDataObject[item])
    // if( item.text  == ''){return true;}
     //return false;


   //var cnt=0;

  //  $("#myForm .dataToAdd").each(function(data) {
  //   //console.log(data.attr('type'));

  //   if(data.attr('type') == text){ 

  //  if(data.value == ''){ alert("difjeriiur");}
  // }

  //   else if(data.attr('type') == select){ 
  //  if(data.value == null){}
  //}    
  // });
//   if (!$('.dataToAdd').val()) {
//     alert('Enter your name!');
// }

//   });


//    $("#myForm .dataToAdd").each(function() {
//     let control = $(this)
//     console.log(this.name)
// })
var flag1;
var flag2;
$("#myForm .dataToAdd").each(function() {
  let control = $(this);
 //var cnt=0;

  if(control.attr('type') == 'text'){
    console.log(control[0].value)
 
     if(control[0].value== ''){
 
       flag1=true;

     }
 
  }
   if(control.attr('type') == 'select'){
     console.log(control[0].value);
   if(control[0].value ==null){

    flag2 = true;
 
  }
 
   }
  
  console.log("dhifugrrrrrrrrrrrrrrrrrrr");
 
  
  if(flag1==false && flag2==false){return true; console.log("dhgggggggggggggggggggg");}
  //console.log(flag);
})

if(flag1==false && flag2==false){return true;}
  else{return false;}
 }

 function idExist(formDataObject){
    
  if(globalArray.find(item=>parseInt(item.id)===parseInt(formDataObject.id))){
    alert("ID already exists"); return true; }
 else { return false; }



  // else{return false;}

}




<<<<<<< HEAD























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

//    });
   
//    if(anyBlankField(formDataObject) == true){

//       globalArray.push(formDataObject);

//     }
//     else {
//       alert("some data fields are blank"); 
//   }
 
   
//     // Clear the DataTable
//     dataTable.clear();

//     // Add each row to the DataTable
//     globalArray.forEach(function(data) {
//       dataTable.row.add(data);
//     });

//     dataTable.draw();

//    clearForm();
//   });
//   var arrToStoreShift = [];
//   $("#onShiftSubmit").click(function(event) {
//     event.preventDefault();

//     var inputData = $("#Select1").val();
//     arrToStoreShift.push( $("#Select1").val());

//    console.log(arrToStoreShift);
//   // var dataToMap; 
//    if($("#Select1").val() != ''){
//    // var dataToMap = $("#Select2").val();
//    jQuery.map(arrToStoreShift, function(val) {  
//     inputData = $("#Select2").val();

//     dataTable.clear();
//     globalArray.forEach(function(data) {
//             dataTable.row.add(data);
//           });
//           dataTable.draw();

//     }); 
    
//   } 

//     //var filteredData;

// //     var filteredDepartment = globalArray.filter(item => item.department === inputData)
   
// //    console.log(filteredDepartment);

// //     if(filteredDepartment.length == 0){
// //         alert("no data found");
// //         dataTable.clear();    
// //          dataTable.draw();
// //     }   
// //     else{
// //         dataTable.clear();

// //     // Add each row to the DataTable
// //     filteredDepartment.forEach(function(data) {
// //       dataTable.row.add(data);
// //     });
// //     dataTable.draw();
// //     }

// // // reset the input field to null
// //     clearForm();
//   }); 




// // dataTable.clear();

// // // Add each row to the DataTable
// // filteredDepartment.forEach(function(data) {
// //   dataTable.row.add(data);
// // });
// // dataTable.draw();

 
// });

// function clearForm(){
//   $('.dataToAdd').val('');
// }
// function anyBlankField(formDataObject){

// var flag1 = false;
// var flag2 = false;
// $("#myForm .dataToAdd").each(function() {
//   let control = $(this);

//   if(control.attr('type') == 'text'){
 
//      if(control[0].value== ''){
 
//        flag1=true;

//      }
 
//   }
//    if(control.attr('type') == 'select'){

//       if(control[0].value =='' || control[0].value ==null){

//     flag2 = true;
 
//   }
//     }  
// })
// if(flag1==false && flag2==false){return true;}
//   else{return false;}
// }



















































//-----------------------------------------code where we are making a data table and adding the 
//array of objects in the data table with two different methods
// first where we are clearing the data of the table each time and adding the recodes 
// second where we are adding only the newly added data and tables previous records are not changed
// now we are checking that if any value(id here) exist already in the dataTable then it should 
// not re-enter the same id instead it should give the alert of id exist already 
//now we are checking the condition where all the data fields should have a not null value, if it
//is not then do not perform the action, if all the data fields are filled then only perform the action
//------------------------------------------------------------------------------------------


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

//    });
   
//     function idExist(formDataObject){
    
//     if(globalArray.find(item=>parseInt(item.id)===parseInt(formDataObject.id))){
//       alert("ID already exists"); return true; }
//    else { return false; }
//  }
//    // .has()

//    if(anyBlankField(formDataObject) == true){
//     if(globalArray.length == 0 || (idExist(formDataObject)===false)){
//       globalArray.push(formDataObject);
//      }
//     }
//     else {
//       alert("some data fields are blank"); 
//   }
 
   
//     // Clear the DataTable
//     dataTable.clear();

//     // Add each row to the DataTable
//     globalArray.forEach(function(data) {
//       dataTable.row.add(data);
//     });

//     dataTable.draw();

// // reset the input field to null
//    // document.getElementById("myForm").reset();
//    // $('.dataToAdd').val('');
//    clearForm();
//   });
//    //var newArray = [];
//   $("#onSubmit").click(function(event) {
//     event.preventDefault();

//     var inputData = $("#exampleFormControlSelectoption").val();
  
//     //var filteredData;

//     var filteredDepartment = globalArray.filter(item => item.department === inputData)
   
//    console.log(filteredDepartment);

//     if(filteredDepartment.length == 0){
//         alert("no data found");
//         dataTable.clear();    
//          dataTable.draw();
//     }   
//     else{
//         dataTable.clear();

//     // Add each row to the DataTable
//     filteredDepartment.forEach(function(data) {
//       dataTable.row.add(data);
//     });
//     dataTable.draw();
//     }

// // reset the input field to null
//     clearForm();
//   }); 
 
// });

// function clearForm(){
//   $('.dataToAdd').val('');
// }
// function anyBlankField(formDataObject){

// // if((formDataObject.id == '') || (formDataObject.name == '')
// //  || (formDataObject.department == null) || (formDataObject.shift == null)){return false;}
// //  else{return true;}

// var flag1 = false;
// var flag2 = false;
// $("#myForm .dataToAdd").each(function() {
//   let control = $(this);

//   if(control.attr('type') == 'text'){
 
//      if(control[0].value== ''){
 
//        flag1=true;

//      }
 
//   }
//    if(control.attr('type') == 'select'){

//       if(control[0].value =='' || control[0].value ==null){

//     flag2 = true;
 
//   }
//     }  
// })
// if(flag1==false && flag2==false){return true;}
//   else{return false;}
// }



//type() ->text       ----> ''
// type() ->select   ----> null
=======
//type() ->text     ''
//
>>>>>>> 7267a4a18d5f054823ef41432a470e7c92b3e2b6





























































































































//-----------------------------------------code where we are making a data table and adding the 
//array of objects in the data table with two different methods
// first where we are clearing the data of the table each time and adding the recodes 
// second where we are adding only the newly added data and tables previous records are not changed
// now we are checking that if any value(id here) exist already in the dataYable then it should 
// not re-enter the same id instead it should give the alert of id exist already 
//------------------------------------------------------------------------------------------

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

//    });
   
//     function idExist(formDataObject){
    
//     if(globalArray.find(item=>parseInt(item.id)===parseInt(formDataObject.id))){
//       alert("ID already exists"); return true; }
//    else { return false; }
//  }
//    // .has()

// if(globalArray.length == 0 || (idExist(formDataObject)===false)){
//     globalArray.push(formDataObject);
//    }
 //    // globalArray.push(formDataObject);
//     //console.log(formDataObject);
    
   
//     // Clear the DataTable
//     dataTable.clear();

//     // Add each row to the DataTable
//     globalArray.forEach(function(data) {
//       dataTable.row.add(data);
//     });

//     dataTable.draw();

// // reset the input field to null
//    // document.getElementById("myForm").reset();
//     $('dataToAdd').val('');
//   });


 

//    //var newArray = [];
//   $("#onSubmit").click(function(event) {
//     event.preventDefault();

//     var inputData = $("#exampleFormControlSelectoption").val();
  
//     //var filteredData;

//     var filteredDepartment = globalArray.filter(item => item.department === inputData)
   
//    console.log(filteredDepartment);

//     if(filteredDepartment.length == 0){
//         alert("no data found");
//         dataTable.clear();     dataTable.draw();
//     }   
//     else{
//         dataTable.clear();

//     // Add each row to the DataTable
//     filteredDepartment.forEach(function(data) {
//       dataTable.row.add(data);
//     });
//     dataTable.draw();
//     }

// // reset the input field to null
//    // $('select').val('');
//    clearForm();
//   }); 

//   function clearForm(){
//     $('dataToAdd').val('');
//   }
// });














//-----------------------------------------code where we are making a data table and adding the 
//array of objects in the data table with two different methods
// first where we are clearing the data of the table each time and adding the recodes 
// second where we are adding only the newly added data and tables previous records are not changed
//------------------------------------------------------------------------------------------
// var globalArray = [];

// $(document).ready(function() {
//   // Initialize DataTable
//   var dataTable = $('#dataTable').DataTable();
//  // let dataTable = new DataTable('#dataTable');

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
//     // dataTable.clear();
//     // globalArray.forEach(function(data) {
//     //   dataTable.row.add([data.shift, data.department, data.name,  data.id]);
//     // });
//     // dataTable.draw();

//   // when we don't want to clear the table-data each time 
//   // Add the new form data directly to the DataTable
//   dataTable.row.add([formDataObject.id, formDataObject.name,
//      formDataObject.department, formDataObject.shift]).draw();
  
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

//    $("#submitButton").click(function(event) {
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










//});
