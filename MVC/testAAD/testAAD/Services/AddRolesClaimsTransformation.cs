using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using testAAD.Helpers;

namespace testAAD.Services
{
    public class AddRolesClaimsTransformation : IClaimsTransformation
    {
        public string _connectionString;

        public AddRolesClaimsTransformation(IConfiguration configration)
        {
            _connectionString = configration.GetConnectionString("DefaultConnection");
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            var identity = (ClaimsIdentity?)principal.Identity;

            // var email = identity.FindFirst(ClaimTypes.Email);




            ClaimsIdentity? claimsIdentity = (ClaimsIdentity?)principal.Identity;

            string claimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";

            var emailClaim = claimsIdentity.FindFirst(claim => claim.Type.ToString() == claimType);

            if (emailClaim != null)
            {
                string email = emailClaim.Value;

                // Now you have the email value, you can use it as needed


                var roles = AddData.ConvertRoleDataTableToList(AddData.GetRoles(email, _connectionString));


                foreach (var role in roles)
                {
                    identity?.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
                }
            }
            return Task.FromResult(principal);
        }


    }
}
