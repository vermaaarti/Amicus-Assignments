
$(document).ready(function(){

let dataTable = intilizeDataTable();

$("#load-data").click(function () {
     loadDataTable({ dataTable })  
})  

// $(`#submit`).click(function(){
//     addNewRowToDatatable({dataTable})
// })

})

function intilizeDataTable(){
   return $('#dataTable').DataTable({
        columns: [
    
            { data: 'country', title: 'Country' },
    
            { data: 'name', title: 'Name' },
    
            { data: 'state-province', title: 'State' }
    
        ],
        lengthChange: false, 
    searching: false,
    info: false,        
    paging: false           
    });
}

function loadDataTable({ dataTable })  {
    $.ajax({

        type: 'GET',
        
        url: 'http://universities.hipolabs.com/search?country=India',
        
        dataType: 'json',
        success: function (data, textStatus, xhr) {
                    dataTable.rows.add(data).draw()
                },
        
        error: function (errorThrown, textStatus,  xhr) {
                    console.log('Error in Operation', error);
                }
            
            });
        
}






