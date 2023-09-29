using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;
using System.Data;
using System.Diagnostics;
using System.Reflection;


namespace MVCAssignment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<DetailedInformation> TotalList()
        {

            EmployeeInfo employee1 = new EmployeeInfo()
            {
                ID = 1,
                Name = "Test",
                Age = 25,
                Address = "Raipur",
                PhoneNumber = "1234567890"
            };
            EmployeeInfo employee2 = new EmployeeInfo()
            {
                ID = 2,
                Name = "Test",
                Age = 25,
                Address = "Raipur",
                PhoneNumber = "1234567890"
            };
            EmployeeInfo employee3 = new EmployeeInfo()
            {
                ID = 3,
                Name = "Test",
                Age = 25,
                Address = "Raipur",
                PhoneNumber = "1234567890"
            };

            OfficeInfo office1 = new OfficeInfo()
            {
                EmployeeDepartment = "IT",
                ManagerName = "Testmanager",
                ManagerDepartment = "IT"
            };
            OfficeInfo office2 = new OfficeInfo()
            {
                EmployeeDepartment = "IT",
                ManagerName = "Testmanager",
                ManagerDepartment = "IT"
            };
            OfficeInfo office3 = new OfficeInfo()
            {
                EmployeeDepartment = "IT",
                ManagerName = "Testmanager",
                ManagerDepartment = "IT"
            };



            // Created a list to store combined data
            List<DetailedInformation> detailedInformation = new List<DetailedInformation>();

            // Adding data to the combined list
            detailedInformation.Add(new DetailedInformation() { EmployeeInfo = employee1, OfficeInfo = office1 });
            detailedInformation.Add(new DetailedInformation() { EmployeeInfo = employee2, OfficeInfo = office2 });
            detailedInformation.Add(new DetailedInformation() { EmployeeInfo = employee3, OfficeInfo = office3 });



            return detailedInformation;
        }

        [Route("/demo/{id}")]
     public IActionResult ViewEmployeeInfo(int id)
    {
            /*var test = TotalList().Find(p=> p.EmployeeInfo.ID == id);

             ViewData["Title"] = test.EmployeeInfo.Name;


             return View(test);*/





           /* public DataSet GetRequestDetailDA(int requestId, string userIdentity)
            {
                DataSet returnDataSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(_connStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[uspGetRequestDetail]";
                    cmd.Parameters.Add(new SqlParameter("@RequestId", requestId));
                    cmd.Parameters.Add(new SqlParameter("@UserIdentity", userIdentity));
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    dataAdp.Fill(returnDataSet);
                    connection.Close();
                }
                return returnDataSet;
            }*/


        }


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