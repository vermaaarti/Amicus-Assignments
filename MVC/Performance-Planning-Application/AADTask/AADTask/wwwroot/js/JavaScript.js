let globalArray = [];
let count = 0;
let plannerEmail ;



$(document).ready(function () {


    $.ajax({
        type: 'GET',
        url: '/Home/EmployeeDataList',
        dataType: 'json',
        success: function (data) {

            initializeAllEmployeeDataTable(data);
            //
            globalArray = data;
         
            console.log(globalArray);
         
        },
      
    });

    $.ajax({
        type: 'GET',
        url: '/Home/FilterEmployeeData/' + email, // Update parameter name to 'email'
        dataType: 'json',
        success: function (data) {
            initializeFilteredDataTable(data);
            globalArray = data;
            console.log(globalArray);
        },
    });

   
})



function initializeAllEmployeeDataTable(data) {
   

    allEmployeeTable = new DataTable('#dataTable', {
        data: data,
        columns: [
            {
                "data": "employeeName",
                "render": function (data, type, row) {
                    return '<a href="/Employee/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                },
            },
            {
                "data": "email",
            },
            {
                "data": "managerName",
            },
            {
                "data": "department",
            },
           /* {
                "data": "performanceRating", // Update the data property
                "render": function (data, type, row) {
                    if (type == 'display') {
                        return '<select>' +
                            '<option selected value="' + data + '">' + data + '</option>' +
                            '<option value="Poor">Poor</option>' +
                            '<option value="Satisfactory">Satisfactory</option>' +
                            '<option value="Good">Good</option>' +
                            '<option value="Excellent">Excellent</option>' +
                            '</select>';
                    }
                    return data;
                }
            },*/
            {
                "data": "plannerName",
            },
        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });
}

function initializeFilteredDataTable(data) {
  

    filteredDataTable = new DataTable('#dataTable', {
        data: data,
        columns: [
            {
                "data": "employeeName",
                "render": function (data, type, row) {
                    return '<a href="/Employee/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                },
            },
            
            {
                "data": "managerName",
            },
            {
                "data": "department",
            },
            {
                "data": "performanceRating", // Update the data property
               
            },
            
        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });
}



/*function initializeDataTable(data) {
    return new DataTable('#dataTable', {
        data: data,
        columns: [
            {
                "data": "employeeName",
                "render": function (data, type, row) {
                    return '<a href="/Employee/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                },
            },
            {
                "data": "email",
            },
            {
                "data": "managerName",
            },
            {
                "data": "department",
            },
            {
                "data": "performanceRating", // Update the data property
                "render": function (data, type, row) {
                    if (type == 'display') {
                        return '<select>' +
                            '<option selected value="' + data + '">' + data + '</option>' +
                            '<option value="Poor">Poor</option>' +
                            '<option value="Satisfactory">Satisfactory</option>' +
                            '<option value="Good">Good</option>' +
                            '<option value="Excellent">Excellent</option>' +
                            '</select>';
                    }
                    return data;
                }
            },
            {
                "data": "plannerName",
            },
        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });
}  */







  /* function SaveEmployee(event) {

    event.preventDefault();

    $.ajax({
        type: 'POST',
        url: '/Home/UpdatedData',
        data: { employeeList: globalArray },
        success: function (data) {

            console.log(data);
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation');
        }
    });
}*/



function AddNewEmployee(event) {

    event.preventDefault();
    window.location.href = "/Home/AddEmployeeForm";

}



// Add a click event handler to your "Add New Employee" button
/*$('#addEmployeeButton').on('click', function () {
    // Load the form using AJAX and display it in a modal or a separate container
    console.log("Hello");
    $.get('/Home/AddEmployeeForm', function (data) {
        // Append the form data to your page or display it in a modal dialog
        $('#modalContainer').html(data);
    });
});*/















 /*function intilizeDataTable(data) {

     return new DataTable('#dataTable', {
            data: data,
         columns: [
                //////////////////////////////////working code

                  /* {
                    "data": "EmployeeName",
                    "render": function (data, type, row) {
                        return '<a href="/Employee/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                       
                    },

                },*/

                /////////////////////////////////////////////working code
          /*   {
                 "data": "",
                 "render": function (data, type, row) {
                     return `<input  class="form-check-input" type="checkbox" value="" id="EmpId" onchange=changeisDeleted(event,${row.employeeId})>`;
                 },

             },

             {
                 "data": "employeeName",
                 "render": function (data, type, row) {
                     return '<a href="/Employee/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                 },

             },

             {
                 data: 'departmentName', render: function (data, type, row) {
                     let color = 'black';
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
                 }
             },
               
                {
                    data : null,
                    "render": function (data, type, row) {
                        if (type == 'display') {
                           
                            return '<select><option value="Poor">Poor</option><option value="Satisfactory">Satisfactory</option><option value="Good">Good</option><option value="Excellent">Excellent</option></select>';
                        }
                   
                        return data;
                    }
                }

                ////////////till here


              //  EmployeeName, ManagerName, Department, PerformanceRating

               
         ],
        
            lengthChange: false,
            searching: false,
            info: false,
            paging: false,
        });

    }*/



