using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;
using System.Diagnostics;


namespace MVCAssignment2.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
            EmployeeInfo employee = new EmployeeInfo()
            {
                ID = 1,
                Name = "Test",
                Age = 25,
                Address = "Raipur",
                PhoneNumber = "1234567890"
            };

            OfficeInfo office = new OfficeInfo()
            {
                EmployeeDepartment = "IT",
                ManagerName = "Testmanager",
                ManagerDepartment = "IT"

            };

            //         DetailedInformation employeeOffice = new DetailedInformation
            //         {
            //	EmployeeInfo = employee,
            //	OfficeInfo = office
            //};

            List<EmployeeInfo> information = new List<EmployeeInfo>(14);
            information.Add(employee);
           // information.Add(office);

            return View(information);
        }


       /* public IActionResult GetDetailedInformation()
        {
            // Create a list of DetailedInformation objects
            List<EmployeeInfo> detailedInformationList = new List<EmployeeInfo>();

            // Add your employee information and office information to the list
            detailedInformationList.Add(
                new EmployeeInfo() { ID = 2, Name = "Johny", Age = 30, Address = "Raipur", PhoneNumber = "1234567890" }
               
            );

            detailedInformationList.Add(
               new EmployeeInfo() { ID=3, Name = "John Doe", Age= 30, Address = "Raipur", PhoneNumber =  "1234567890" }
             
           );



            // Create a list of DetailedInformation objects
          //  List<OfficeInfo> detailedInformation = new List<OfficeInfo>();

         



            // Return the list of DetailedInformation objects
            // return Ok(detailedInformationList);
        }
		*/


        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}