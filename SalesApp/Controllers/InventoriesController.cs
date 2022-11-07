using Microsoft.AspNetCore.Mvc;

namespace SalesApp.Controllers
{
    public class InventoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
