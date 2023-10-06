var globalArray = [];
$(document).ready(function () {

      
    $.ajax({
        type: 'GET',
        url: '/Employee/JSONEmployeeData',
        dataType: 'json',
        success: function (data) {
          
            intilizeDataTable(data);
            globalArray = data;
            console.log(globalArray);
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation', error);
        }
    });

   // trackChanges(data);
   



    


})

function intilizeDataTable(data) {
   new DataTable( '#dataTable',{
        data: data,
        columns: [

            
            {
                "data": "employeeName",
                "render": function (data, type, full, meta) {
                    return '<input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">' ;
                },

            }, 

            {
               "data": "employeeName",
                "render": function (data, type, full, meta) {
                    return '<a href="">' + data + '</a>';
                },
               
            },

          {
              data: 'departmentName', render: function (data, type, row) {
                  var color = 'black';
                  if (data == 'IT') {
                      color = 'yellow';
                  }
                  if (data == 'HR') {
                      color = 'red';
                  }
                  if (data == 'Finance') {
                      color = 'green';
                  }
                  return '<span style="color:' + color + '">' + data + '</span>';
              } },

             {
                "data": "amountPerYear",
                 "render": function (data, type, full, meta) {
                     var inputData = $("#amount").val();
                     console.log(inputData);
                    return '<input type="text" onchange="myFunction(this.value)" class="form-control" id="amount" value='+data+'>';
                }

            },
           

        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
   });

}

function myFunction(val) {

    alert("The input value has changed. The new value is: " + val);
   // $('amountField').text(this.AmountPerYear) = val;
    globalArray = globalArray.map(function (item) {
        if (inputData != val) {
            globalArray.forEach(function (data) {
                globalArray.amountPerYear = val;
                console.log("data added");

            });
        }
       // return item;
        
    });
   
   
}

/*function trackChanges(data) {

  
    var table = $('#dataTable').DataTable();



    // Event handler for cell edit

    table.on('cell().data()', function (e, datatable, cell) {

        var originalValue = cell.data();

        var editedValue = cell.node().innerText.trim(); // Get the current cell's text



        if (originalValue !== editedValue) {

            // The value has been edited

            console.log("Value edited from " + originalValue + " to " + editedValue);



            // You can perform further actions here, like updating a global variable or sending the data to the server.

        }

    });

}*/

//function intilizeDataTable(data) {






