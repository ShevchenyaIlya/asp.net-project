using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET
        public IActionResult Product()
        {
            return View();
        }
    }
}