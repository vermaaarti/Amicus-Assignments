
$(document).ready(function () {

    let dataTable = intilizeDataTable();

   // $("#load-data").click(function () {
        loadDataTable({ dataTable })
   // })



})

function intilizeDataTable() {
    return $('#dataTable').DataTable({
        columns: [

            
            { data: '', title: '...' },

            { data: 'employeeName', title: 'EmployeeName' },

            { data: 'departmentName', title: 'EmployeeDepartment' },

            { data: 'amountPerYear', title: ' AmountPerYear' }

        ],
        lengthChange: false,
        searching: false,
        info: false,
        paging: false
    });

}

function loadDataTable({ dataTable }) {
    $.ajax({

        type: 'GET',

        url: 'https://localhost:44303/Employee/JSONEmployeeData',

        dataType: 'json',
        success: function (data, textStatus, xhr) {
            dataTable.rows.add(data).draw()
        },

        error: function (errorThrown, textStatus, xhr) {
            console.log('Error in Operation', error);
        }

    });

}
