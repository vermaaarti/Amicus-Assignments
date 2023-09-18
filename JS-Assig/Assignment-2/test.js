
// loading data from API using fetch method

// const fetchData = document.getElementById("load-data");

//     fetchData.addEventListener("click", function(){
  
//   fetch('http://universities.hipolabs.com/search?country=India', {

//   method: 'GET'

// })

// .then(response => response.json())

// .then(data => {

//   // Handle the data here
//   // console.log('Data from API:', data);

//   $('#dataTable').DataTable({

//                   data: data,
    
//                   columns: [
    
//                       { data: 'country', title: 'Country' },
    
//                       { data: 'name', title: 'Name' },
    
//                       { data: 'state-province', title: 'State' }
    
//                   ],
//                   lengthChange: false, 
//         searching: false,
//         info: false,        
//         paging: false 
    
//               });

// })

// .catch(error => {

//   console.error('Error:', error);

// });

//     });









// loading data from API using ajax

const fetchData = document.getElementById("load-data");

   fetchData.addEventListener("click", function(){

  $.ajax({

      type: 'GET',

url: 'http://universities.hipolabs.com/search?country=India',

    //  dataType: 'jsonp',

      success: function(data) {

         // console.log('data: ', data);

          $('#dataTable').DataTable({

              data: data,

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

      },

      error: function(xhr, status, error) {

          console.log('there is some error', error);

      }

  });

});