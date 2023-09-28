using Microsoft.AspNetCore.Mvc;

namespace Assignment1_attributeR.Controllers
{
    public class ProductsController : Controller
    {
      
        [Route("/")]
        [Route("/AmicusProducts")]
        [Route("/AmicusProducts/Index")]
       
        public IActionResult Index()
        {
            return View();
        }
        [Route("AmicusProducts/Details/{id:int:minlength(3)}")]
     
        public IActionResult Details(int id)
        {
        
                return View();
         
            
        }

    }
}
