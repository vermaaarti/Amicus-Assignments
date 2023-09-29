using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCAssignment2.Models;
using System.Data;
using System.Diagnostics;
using System.Reflection;


namespace MVCAssignment2.Controllers
{
    public class HomeController : Controller
    {
        
       

        private readonly string connectionString;
        public HomeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public DataSet GetEmployeeOfficeInfo(int ID)

            {
                DataSet returnDataSet = new DataSet();

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    connection.Open();

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = connection;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "getEmployeeOfficeDetails"; // Use the name of your stored procedure

                    cmd.Parameters.Add(new SqlParameter("@EmpId", ID));

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    dataAdp.Fill(returnDataSet);

                    connection.Close();

                }

                  return returnDataSet;

           
        }

        public DetailedInformation DatasetToDetailedInformation(DataSet dataSet)
        {
            var fTable = dataSet.Tables[0];
            var sTable = dataSet.Tables[1];

        List<EmployeeInfo>employeeInfos = fTable.AsEnumerable().Select(fdata =>
        new EmployeeInfo()
        {
         ID = fdata.Field<int>("ID"),
         Name = fdata.Field<string>("Name"),
         Age = fdata.Field<int>("Age"),
         Address = fdata.Field<string>("Address"),
         PhoneNumber = fdata.Field<string>("PhoneNumber")
        }).ToList();

            List<OfficeInfo> officeInfos = sTable.AsEnumerable().Select(sdata =>
            new OfficeInfo()
            {
                EmployeeDepartment = sdata.Field<string>("EmployeeDepartment"),
                ManagerName = sdata.Field<string>("ManagerName"),
                ManagerDepartment = sdata.Field<string>("ManagerDepartment"),
            }).ToList();

            DetailedInformation completeInfo = new DetailedInformation(employeeInfos[0], officeInfos[0]);
           
            return completeInfo;
        }

        public ActionResult ViewEmployeeInfo(int ID)
        {
            DataSet dataSet = GetEmployeeOfficeInfo(ID);
            DetailedInformation result = DatasetToDetailedInformation(dataSet);
            return View(result);
        }
        public IActionResult Index()
        {
            return View();
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