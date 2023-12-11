﻿using AADTask.Models;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

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



        // fn to get the employees based on admin or planner
        public DataTable EmployeeData()

        {

            var claimsIdentity = User.Identities.FirstOrDefault();
            
                var emailClaim = claimsIdentity?.Claims;
               
                    var email = emailClaim.FirstOrDefault((p) => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;

            DataTable returnDataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "procedureToGetEmployeeData_aartiL"; // Use the name of your stored procedure

                cmd.Parameters.Add(new SqlParameter("@Email", email));

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

                newObj.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                newObj.EmployeeName = dr["EmployeeName"].ToString();
                newObj.EmployeeEmail = dr["EmployeeEmail"].ToString();
                newObj.ManagerName = dr["ManagerName"].ToString();
                newObj.PlannerName = dr["PlannerName"].ToString();
                newObj.Department = dr["Department"].ToString();
                newObj.PerformanceRating = dr["PerformanceRating"].ToString();
                newObj.performanceChallenges = dr["performanceChallenges"].ToString();
                newObj.StatusOfPlanning = dr["StatusOfPlanning"].ToString();
                newObj.PlannerId = Convert.ToInt32(dr["PlannerId"]);
                newObj.ApproverId = Convert.ToInt32(dr["ApproverId"]);
                newObj.CreatedOn = dr["CreatedOn"].ToString();
                newObj.ApprovalStatus = dr["ApprovalStatus"].ToString();

                objectList.Add(newObj);
            }
            return objectList;
        }

      
        // fn to convert data into json
        public IActionResult JSONEmployeeData()
        {
            var Data = ConvertTableIntoModel(EmployeeData());
            return Ok(Data);
        }



        [HttpGet]
        public IActionResult GetEmployeeData()
        {
             var filteredData = ConvertTableIntoModel(EmployeeData());
            return View("EmployeeDataList", filteredData);
        }




        // fn to save data on database when submit button is clicked by the planner
        public DataTable UpdateEmployeeStatus(List<AllEmployee> employeeList)

        {

            var returnDataTable = new DataTable();
            var JSONData = JsonConvert.SerializeObject(employeeList);

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ChangeStatusToInProgress";  //  ChangeStatusToCompleted_a  // Use the name of your stored procedure

                cmd.Parameters.Add(new SqlParameter("@JsonEmployee", JSONData));

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }
            return returnDataTable;


        }


        // fn to add data into the task table
        public DataTable AddDataIntoTaskTable(List<AllEmployee> employeeList)

        {

            var claimsIdentity = User.Identities.FirstOrDefault();

            var emailClaim = claimsIdentity?.Claims;

            var email = emailClaim.FirstOrDefault((p) => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;

            var returnDataTable = new DataTable();
            var JSONData = JsonConvert.SerializeObject(employeeList);
          
            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AddDataIntoApproverTableU"; // Use the name of your stored procedure

                cmd.Parameters.Add(new SqlParameter("@ApproverEmail", email));

                cmd.Parameters.Add(new SqlParameter("@EmpJson", JSONData));

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }

            return returnDataTable;

        }

        [HttpPost]
        public IActionResult AddDataIntoTaskTableForResult(List<AllEmployee> employeeList)
        {
            var data = AddDataIntoTaskTable(employeeList);
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult UpdateStatusToCompleted(List<AllEmployee> employeeList)
        {
            
            var data = UpdateEmployeeStatus(employeeList);
            
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // fn ends here





        // fn to send the updated array to the database after changing the performance rating 
        public DataTable UpdatedRawData(List<AllEmployee> employeeList)

        {

            var returnDataTable = new DataTable();
            var JSONData = JsonConvert.SerializeObject(employeeList);
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SaveEmployeeDatasAsDraft_artiA"; // Use the name of your stored procedure

                cmd.Parameters.Add(new SqlParameter("@JsonEmployee", JSONData));

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }
            return returnDataTable;


        }


        [HttpPost]
        public IActionResult UpdatedData(List<AllEmployee> employeeList)
        {
            var data = UpdatedRawData(employeeList);
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        // fn ends here



        //   method to update employees existing record by clicking on their name and adding new employee 
        public IActionResult AddEmployeeForm(EmployeeList employeeList)
        {

            return View(new AllEmployee());
        }
      

        public DataTable AddUpdateEmployee(AllEmployee employeeList)
        {
            var returnDataTable = new DataTable();
            var JsonData = JsonConvert.SerializeObject(employeeList);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertOrUpdateEmployee";
                cmd.Parameters.Add(new SqlParameter("@EmpJson", JsonData));
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                dataAdp.Fill(returnDataTable);
                connection.Close();
            }
            return returnDataTable;
        }

        [HttpPost]
        public IActionResult AddToTable(AllEmployee empList)
        {
            AddUpdateEmployee(empList);

           
            return Ok();
        }

        public IActionResult EmployeeDetailView(int id)
        {
            if (id != 0)
            {
                var data = ConvertTableIntoModel(EmployeeData());
                var filteredData = data.FirstOrDefault(row => row.EmployeeId == id);
                return View(filteredData);

            }
            var emptyData = new AllEmployee();
            return View(emptyData);

        }

        //fn ends here



        // fn to go to the approver page

         public DataTable ApproverEmployeeData()
        {
            var claimsIdentity = User.Identities.FirstOrDefault();
            var emailClaim = claimsIdentity?.Claims;
            var email = emailClaim.FirstOrDefault((p) => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;

            DataTable returnDataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShowEmployeForApproverM"; // Updated the procedure name
                cmd.Parameters.Add(new SqlParameter("@EmployeeEmail", email)); // Pass email directly as a parameter

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                dataAdp.Fill(returnDataTable);

                connection.Close();
            }

            return returnDataTable;
        }


        public List<AllEmployee> ConvertTableIntoModels(DataTable returnDataTable)
        {
            List<AllEmployee> objectList = new List<AllEmployee>();

            foreach (DataRow dr in returnDataTable.Rows)
            {
                AllEmployee newObj = new AllEmployee();

                newObj.ApprovalTaskId = Convert.ToInt32(dr["ApprovalTaskId"]);
                newObj.EmployeeName = dr["EmployeeName"].ToString();
                newObj.PlannerName = dr["PlannerName"].ToString();
                newObj.ApproverName = dr["ApproverName"].ToString();
                newObj.ApprovalStatus = dr["ApprovalStatus"].ToString();
                newObj.CreatedOn = dr["CreatedOn"].ToString();

               
                objectList.Add(newObj);
            }
            return objectList;
        }
        

        // fn to convert data into json
        public IActionResult ApproverJSONEmployeeData()
        {
            var Data = ConvertTableIntoModels(ApproverEmployeeData());
            return Ok(Data);
        }


        //fn ends here

        public IActionResult ApproverView() {
          //  var data = AddDataIntoTaskTable();
           
            return View("ApproverView");
           }


        // fn to update(change) the employee assigned status into approved status
        public DataTable UpdateEmployeeAssignedStatus(List<AllEmployee> employeeList)

        {
            var claimsIdentity = User.Identities.FirstOrDefault();
            var emailClaim = claimsIdentity?.Claims;
            var email = emailClaim.FirstOrDefault((p) => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;


            var returnDataTable = new DataTable();
            var JSONData = JsonConvert.SerializeObject(employeeList);
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ChangeStatusToApprovedI";  //  ChangeStatusToCompleted_a  // Use the name of your stored procedure

                cmd.Parameters.Add(new SqlParameter("@JsonEmployee", JSONData));

                cmd.Parameters.Add(new SqlParameter("@ApproverEmail", email));

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }
            return returnDataTable;


        }

        [HttpPost]
        public IActionResult UpdateAssignedStatusToApproved(List<AllEmployee> employeeList)
        {
           

            var data = UpdateEmployeeAssignedStatus(employeeList);
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // fn ends here



        // fn to update(change) the approvalStatus from assigned to Unassigned
        public DataTable UpdateAssignedToUnassigned()

        {
           
            var returnDataTable = new DataTable();
            //var JSONData = JsonConvert.SerializeObject();
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ChangeStatusToUnassignedB"; // Use the name of your stored procedure

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }
            return returnDataTable;


        }

        [HttpPost]
        public IActionResult UpdateAssignedStatusToUnassigned()
        {


            var data = UpdateAssignedToUnassigned();
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        // fn ends here













        public IActionResult EmployeeList()
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