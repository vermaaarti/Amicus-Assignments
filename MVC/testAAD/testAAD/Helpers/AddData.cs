using System.Data;
using System.Data.SqlClient;
using testAAD.Models;

namespace testAAD.Helpers
{
    public class AddData
    {

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


    }

  
}

