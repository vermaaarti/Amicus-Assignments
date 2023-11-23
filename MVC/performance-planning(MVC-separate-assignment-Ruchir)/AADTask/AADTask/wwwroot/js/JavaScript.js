let globalArray = [];
let obj = {};
let employeeId;
let employeeName;
let employeeEmail;
let managerName;
let department;
let plannerName;
let newJsonData;



$(document).ready(function () {


    CreateDataTable();

});

function CreateDataTable() {

    $.ajax({
        type: 'GET',
        url: 'JSONEmployeeData',
        dataType: 'json',
        success: function (data) {
            globalArray = data;
            intilizeDataTable(globalArray);
            console.log(globalArray);
          //  tempArray = globalArray.slice();
            //console.log(tempArray);
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation', errorThrown);

        }
    });
}
console.log(globalArray.length);

    
/*$('#plannerEmailField').on('change', function () {
    var selectedEmail = $('#plannerEmailField').val(); // Get the selected email
    $('#plannerEmailField').val(selectedEmail); // Set the hidden field's value
});*/

/*function initializeAllEmployeeDataTable(data) {
   

    allEmployeeTable = new DataTable('#dataTable', {
        data: data,
        columns: [
            {
                "data": "EmployeeName",
                "render": function (data, type, row) {
                    return '<a href="/Home/EmployeeDetailView/?id=' + row.employeeId + '">' + data + '</a>';
                  
                },
            },
            {
                "data": "EmployeeEmail",
            },
            {
                "data": " ManagerName",
            },
            {
                "data": "Department",
            },
          
            {
                "data": "PlannerName",
            }
            
        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });
}*/

function intilizeDataTable(globalArray) {
   new DataTable('#dataTable', {
        data: globalArray,
       columns: [  
          
            {
                data: "employeeName",
                'render': function (data, type, row) {
                    return '<a href="/Home/EmployeeDetailView/?id=' + row.employeeId + '" class = "idfield">' + data + '</a>';
                },
            },
            {
                data: "employeeEmail",

            },
            {
                data: "managerName",
            },
             {
                 data: "plannerName",
            },
            {
                data: "department",
            },
           {
                "render": function (data, type, row) {  // window.location.href()

                   if (row.statusOfPlanning == "Completed") {
                     //  flag = 1;
                       return `<span>${row.performanceRating}</span>`;
                  
                   }
                   else {
                    //   flag = 0;
                        return `<select class="optionValue" id="performanceRatingDropdown${row.employeeId}" onchange = "SaveAsDraft(${row.employeeId})">
                       <option value="" >select an option</option>
                       <option value="Poor" ${row.performanceRating == "Poor" ? "selected" : ''}>Poor</option>
                       <option value="Satisfactory" ${row.performanceRating === "Satisfactory" ? "selected" : ''}>Satisfactory</option>
                       <option value="Good" ${row.performanceRating == "Good" ? "selected" : ''}>Good</option>
                       <option value="Excellent" ${row.performanceRating == "Excellent" ? "selected" : ''}>Excellent</option>
                       </select >`;
                      
                   }

                }
            },
            {
                data: "statusOfPlanning",
            }
            
        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });

}




// fn to save employee data after changing the performance rating
function SaveEmployee(event) {
    event.preventDefault();

   

    $.ajax({
        type: 'POST',
        url: 'UpdatedData',
        data: { employeeList: globalArray },
        success: function (data) {

            console.log(globalArray);
 
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation');
        }
    });


}



function SaveAsDraft(employeeId) {
    // Find the specific employee in globalArray based on the employeeId
    const employee = globalArray.find(e => e.employeeId == employeeId);

    if (employee) {
        // Update the performance rating for the specific employee
        employee.performanceRating = $('#performanceRatingDropdown' + employeeId).val();
    }

}



// fn to save employees data by planner when submit button is clicked

function Submit(event) {
    event.preventDefault();

  
    // Check if all performance ratings are selected
    var allRatingsSelected = checkAllRatingsSelected();

    if (allRatingsSelected) {
        SaveEmployee(event);
        // If all ratings are selected, proceed with the AJAX request
        $.ajax({
            type: 'POST',
            url: 'UpdateStatusToCompleted',
            data: { employeeList: globalArray },
            success: function () {
                alert('Status of planning changed to Completed.');
               // changeDataTable();
                console.log(globalArray);
                location.reload(true);
            },
            error: function (errorThrown, textStatus, xhr) {
                console.log('Error in Operation');
            }
        });
    } else {
        // If not all ratings are selected, show an alert
        alert('Some performance ratings are not selected. Please select all ratings before submitting.');
    }
}

function checkAllRatingsSelected() {
    var allRatingsSelected = true;

    // Iterate over the global array and check if all ratings are selected
    globalArray.forEach(function (item) {
        var performanceRatingDropdown = `#performanceRatingDropdown${item.employeeId}`;
        var selectedRating = $(performanceRatingDropdown).val();

        // Check if the performance rating is not selected
        if (selectedRating === "") {
            allRatingsSelected = false;
            return false; // Break out of the loop
        }
    });

    return allRatingsSelected;
}


// fn ends here




   function AddEmployeeIntoDataTable() {
       
    $.ajax({
        type: 'POST',
        url: '/Home/AddToTable',
        data: { empList: obj },
        success: function (data) {

            window.location.href = "/Home/GetEmployeeData";

            console.log(data);
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation');
        }
    });
}


// fn to redirect into method to add new employee

function AddNewEmployee(event) {

    event.preventDefault();

    
  
    window.location.href = "/Home/EmployeeDetailView/";

}

function SaveEmployeeDetails(event, employeeId) {
    event.preventDefault();

    $.ajax({
        type: 'GET',
        url: '/Home/JSONEmployeeData',
        dataType: 'json',
        success: function (data) {
            globalArray = data;
            console.log(globalArray);
            if (ValidateForm()) {

               // adding new employee
                if (employeeId == 0) {
                    AddEmployeeIntoDataTable();
                } 
                // updating existing employee
                else {
                    for (var i = 0; i < globalArray.length; i++) {
                        if (globalArray[i].employeeId == employeeId) {
                            if (globalArray[i].statusOfPlanning == 'draft') {
                                AddEmployeeIntoDataTable();
                            }
                            else {
                                alert("can't update data as planning is completed");
                                window.location.href = "/Home/GetEmployeeData";
                            }
                           
                        }
                    }
                }
               

            }
            else {
                alert("some fields are blank");
            }
        },
        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation', errorThrown);

        }
    });

}





function ValidateForm() {

    employeeId = $("#employeeId")[0].value;
    employeeName = $("#employeeName")[0].value;
    employeeEmail = $("#employeeEmail")[0].value;
    managerName = $("#managerName")[0].value;
    department = $("#department")[0].value;
    plannerName = $("#plannerName")[0].value;

    obj = {
        employeeId: employeeId,
        employeeName: employeeName,
        employeeEmail: employeeEmail,
        managerName: managerName,
        department: department,
        plannerName: plannerName
    }


    if (employeeId && employeeName && employeeEmail && managerName && department && plannerName) {
        return true;
    }
    else {
        return false;
    }

}



















       



