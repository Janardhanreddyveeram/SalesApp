using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesApp.Services;

namespace SalesApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductHttpService _productHttpService;        
        private readonly ILogger<ProductsController> _logger;
        //private readonly IUnitOfWork unitOfWork;
        //private readonly IMapper _mapper;
        public ProductsController(ILogger<ProductsController> logger, IProductHttpService productHttpService)
        {
            _productHttpService = productHttpService;
            _logger = logger;            
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productHttpService.GetAllAsync();
            return View(result.Record);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel product)
        {
            var response = await _productHttpService.AddAsync(product);            
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {                
                TempData["error"] = response.Message;
                return View(product);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {

                var response = await _productHttpService.GetAsync(id.Value);

                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    TempData["success"] = response.Message;
                    return View(response.Record);
                }
                else
                {
                    TempData["error"] = response.Message;
                    return NotFound();

                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var response = await _productHttpService.UpdateAsync(product);

            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(product);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }

            var response = await _productHttpService.GetAsync(id.Value);
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                TempData["success"] = response.Message;
                return View(response.Record);
            }
            else
            {
                TempData["error"] = response.Message;
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletPost(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }
            else
            {
                var response = await _productHttpService.DeleteAsync(id.Value);

                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = response.Message;
                    return NotFound();
                }
            }
        }
    }
}
