using Microsoft.AspNetCore.Mvc;

namespace SalesApp.Controllers
{
    public class OrderListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
