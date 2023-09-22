using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class ProductsController: Controller
    {
        
        //GET : ProductsController
        public ActionResult Index()
        {
            return View();
        }
        //GET : ProductsController/Details/1
        public ActionResult Details(int id)
        {
            return View();
        }
        //GET : ProductsController/Create
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
