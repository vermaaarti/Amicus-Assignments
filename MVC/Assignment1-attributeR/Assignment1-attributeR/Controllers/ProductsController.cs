using Microsoft.AspNetCore.Mvc;

namespace Assignment1_attributeR.Controllers
{
    public class ProductsController : Controller
    {
       /* public IActionResult Index()
        {
            return View();
        }*/
        [Route("/")]
        [Route("/AmicusProducts")]
        [Route("/AmicusProducts/Index")]
       
        public IActionResult Index()
        {
            return View();
        }
        [Route("AmicusProducts/Details/{id:int:min(100)}")]
       // [Route("AmicusProducts/Details/{id}")]
        public IActionResult Details(int id)
        {
           // if (id > 99)
          //  {
                return View();
            //}
            
        }

    }
}
