using Microsoft.AspNetCore.Mvc;

namespace MVC_Start.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
