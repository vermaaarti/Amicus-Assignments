using AADTask.Models;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace AADTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly string connectionString;
        public HomeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }


        public DataTable EmployeeData()

        {
            DataTable returnDataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ShowEmployes"; // Use the name of your stored procedure

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }

            return returnDataTable;
        }

        public List<AllEmployee> ConvertTableIntoModel(DataTable returnDataTable)
        {
            List<AllEmployee> objectList = new List<AllEmployee>();

            foreach (DataRow dr in returnDataTable.Rows)
            {
                AllEmployee newObj = new AllEmployee();

                //newObj.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                newObj.EmployeeName = dr["EmployeeName"].ToString();
                newObj.Email = dr["employeeemail"].ToString();
                newObj.ManagerName = dr["managername"].ToString();
                newObj.Department = dr["department"].ToString();
                newObj.PerformanceRating = dr["performancerating"].ToString();
                newObj.PlannerName = dr["plannerName"].ToString();


                objectList.Add(newObj);
            }
            return objectList;
        }

             
        public IActionResult EmployeeDataList()
        {
           var  allemployeedata = ConvertTableIntoModel(EmployeeData());

            return Ok(allemployeedata);
        }





        public DataTable GetEmployeesByPlanner(string Email) // Update parameter name to 'Email'
        {
            DataTable returnDataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEmployeeByPlanner";
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)); // Update data type
                cmd.Parameters["@Email"].Value = Email; // Update parameter name to 'Email'

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                dataAdp.Fill(returnDataTable);
                connection.Close();
            }
            return returnDataTable;
        }


        [HttpGet]
        public IActionResult GetEmployeeData(string plannerEmail)
        {
            var filteredData = ConvertTableIntoModel(GetEmployeesByPlanner(plannerEmail));
            return Json(filteredData);
        }
        
     
        public IActionResult FilterEmployeeData(string plannerEmail)
        {
            var filteredData = ConvertTableIntoModel(GetEmployeesByPlanner(plannerEmail));
            return View("EmployeeDataList", filteredData);
        }




        [HttpPost]
        public IActionResult AddEmployee(AllEmployee model)  // Define your ViewModel if needed
        {
            if (ModelState.IsValid)
            {
                // Retrieve data from the model and call the stored procedure to add the new employee
                var employeMasterid = model.EmployeMasterId;
                var employeeName = model.EmployeeName;
                var employeeemail = model.Email; // Corrected the variable name to match the stored procedure parameter
                var ManagerName = model.ManagerName;
                var department = model.Department;
                var plannerName = model.PlannerName;

                // Call the stored procedure to insert the new employee
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("AddNewEmployes", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeMasterId", employeMasterid));
                        cmd.Parameters.Add(new SqlParameter("@EmployeeName", employeeName));
                        cmd.Parameters.Add(new SqlParameter("@employeeemail", employeeemail));
                        cmd.Parameters.Add(new SqlParameter("@ManagerName", ManagerName));
                        cmd.Parameters.Add(new SqlParameter("@Department", department));
                        cmd.Parameters.Add(new SqlParameter("@PlannerName", plannerName));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Redirect to a success page or return a JSON response
                return RedirectToAction("Success");
            }

            // If the model is not valid, return the form view with validation errors
            return View("AddEmployee", model);
        }

        public IActionResult AddEmployeeForm()
        {
            // Return a partial view containing the HTML for the form
            return PartialView("AddEmployeeForm");
        }
















        // fn to send the updated array to the database after changing the performance rating 
        /* public DataTable UpdatedRawData(List<EmployeeList> employeeList)

         {

             var returnDataTable = new DataTable();
             var JSONData = JsonConvert.SerializeObject(employeeList);
             using (SqlConnection connection = new SqlConnection(connectionString))

             {
                 connection.Open();

                 SqlCommand cmd = new SqlCommand();

                 cmd.Connection = connection;

                 cmd.CommandType = CommandType.StoredProcedure;

                 cmd.CommandText = "SaveEmployeePerformanceRating"; // Use the name of your stored procedure

                 cmd.Parameters.Add(new SqlParameter("@JsonEmployee", JSONData));

                 SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                 dataAdp.Fill(returnDataTable);

                 connection.Close();

             }
             return returnDataTable;


         }


         [HttpPost]
         public IActionResult UpdatedData(List<EmployeeList> employeeList)
         {
             var data = UpdatedRawData(employeeList);
             if (data != null)
             {
                 return Ok();
             }
             return BadRequest();
         }*/









        public IActionResult EmployeeList()
        {

            return View();
        }



        public IActionResult Index()
        {
            var claimsIdentity = User.Identities.FirstOrDefault();
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity?.Claims;
                if (emailClaim != null)
                {
                    var data = emailClaim.FirstOrDefault((p) => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;


                    ViewData["name"] = data;

                    return View();
                }
            }

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