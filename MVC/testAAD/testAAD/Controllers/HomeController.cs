using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using testAAD.Models;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;





namespace testAAD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;
        private readonly string _connectionString;
        private object _dbContext;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public static DataTable GetRoles(string email, string _connectionString)
        {
            DataTable returnDataTable = new();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "EmployeeRolesInfo";
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                dataAdp.Fill(returnDataTable);
                connection.Close();
            }
            return returnDataTable;
        }

        public static List<Roles> ConvertRoleDataTableToList(DataTable dataTable)
        {

            List<Roles> RoleList = dataTable.AsEnumerable().Select(firstData =>
                new Roles()
                {
                    RoleId = firstData.Field<int>("RoleId"),

                    RoleName = firstData.Field<string>("RoleName"),

                }).ToList();

            return RoleList;
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

                   // List<Roles> data = ConvertRoleDataTableToList();

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