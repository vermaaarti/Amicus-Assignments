using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_Assignment3.Models;
using MVCAssignment2.Models;
using System.Data;
//json stringBuilder
//using static System.Net.Mime.MediaTypeNames;
//using System.Text;


namespace MVC_Assignment3.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly string connectionString;
        public EmployeeController(IConfiguration config)
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

                cmd.CommandText = "DepartmentEmployeeSalaryDetail"; // Use the name of your stored procedure

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                dataAdp.Fill(returnDataTable);

                connection.Close();

            }

            return returnDataTable;
        }

        public List<object> ConvertTableIntoModel(DataTable returnDataTable)
        {
            List<object> objectList = new List<object>();

            foreach (DataRow dr in returnDataTable.Rows)
            {
                EmployeeList newObj = new EmployeeList();
             
                newObj.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);  // Beware of the possible conversion errors due to type mismatches
                newObj.EmployeeName = dr["EmployeeName"].ToString();
                newObj.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                newObj.SalaryInformationId = Convert.ToInt32(dr["SalaryInformatonId"]);
                newObj.DepartmentName = dr["DepartmentName"].ToString();
                newObj.AmountPerYear = Convert.ToInt32(dr["AmountPerYear"]);
                 newObj.IsDeleted = 0;

                objectList.Add(newObj);
            }
            return objectList;
        }

        public IActionResult JSONEmployeeData()
        {
            var Data = ConvertTableIntoModel(EmployeeData());
            return Ok(Data);
        }

        
        public IActionResult EmployeeList()
        {
             return View();
        }


    }
}
