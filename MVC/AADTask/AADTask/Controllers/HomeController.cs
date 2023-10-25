using AADTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AADTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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