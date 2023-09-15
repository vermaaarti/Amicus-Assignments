
  //   const fetchData = document.getElementById("load-data");

  //   fetchData.addEventListener("click", function(){

  //   fetch("http://universities.hipolabs.com/search?country=India")
  //   .then(function(resolve){

  //   if(!resolve.ok){
  //   throw new Error("some error");
  //   }
  //   return resolve.json();
  //   })
  //   .then(function(myData){
  //     console.log("do something here", myData);

  // //    var dataTable = $('#dataTable').DataTable({
  // //   columns: [
  // //     { data: 'country', title: 'Country' },
  // //     { data: 'name', title: 'Name' },
  // //     { data: 'state', title: 'State' }
  // //   ],
  // //   lengthChange: false, 
  // //   searching: false,
  // //   info: false,        
  // //   paging: false 
  // // });

         
    
  //   })
  //   .catch(function(error){
  //     console.log("some fetching error is there");
  //   })

  //   })










//   fetch('http://universities.hipolabs.com/search?country=India', {

//   method: 'GET'

// })

// .then(response => response.json())

// .then(data => {

//   // Handle the data here

//   console.log('Data from API:', data);

// })

// .catch(error => {

//   console.error('Error:', error);

// });









  

  $(function(){
  $.ajax({  
    type: 'GET', 
    url: 'http://universities.hipolabs.com/search?country=India',
    //  dataType:'jsonp',
    // cache: false,
    //     crossDomain: true,
        // jsonp: 'callback',   
    success: function (data, status, xhr) {
      console.log('data: ', data);

      $('#dataTable').DataTable({
        data: data,
        columns: [
              { data: 'country', title: 'Country' },
              { data: 'name', title: 'Name' },
              { data: 'state', title: 'State' }
            ]           
      }); 
    },
    error: function (xhr, status, error) {
      console.log('there is some error', error);
          }
  });  
});