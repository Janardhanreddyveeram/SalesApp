using Microsoft.AspNetCore.Mvc;
using SalesApp.Core.Entities;
using SalesApp.Core.Repositories;
using SalesAppData.Repositories.Base;
using SalesAppServices.Models;
using System.Net;

namespace SalesAppServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerFactory loggerFactiory;
        //private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public ProductController(ILoggerFactory loggerFactiory, IUnitOfWork unitOfWork)
        {
            this.loggerFactiory = loggerFactiory;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<Product>>>> GetAllRecordsAsync()
        {
            var results = await unitOfWork.Products.GetAllAsync("Inventories,OrderList");
            if (results == null || results.Count == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "No records found" });
            }
            else
            {
                return Ok(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = results.ToList<Product>() });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Product>>> GetRecordAsync(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "categroy id was not proper" });
            }
            var result = await unitOfWork.Products.GetByIdAsync(id.Value, "Inventories,OrderList");
            if (result == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = $"No record found with the give id: {id.Value}" });
            }
            else
            {
                return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.Found, Message = "Record found", Record = result });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Product>>> Create([FromBody] Product product)
        {
            var result = await unitOfWork.Products.AddAsync(product);
            return CreatedAtAction("Create", new ResponseModel<Product> { ResponseCode = HttpStatusCode.Created, Message = "Product created successfully", Record = result });
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<Product>>> Edit([FromBody] Product product)
        {
            if (product.Id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product does not have id" });
            }
            var found = await unitOfWork.Products.GetByIdAsync(product.Id);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product not found" });
            }
            var result = await unitOfWork.Products.UpdateAsync(product);
            return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.OK, Message = "Product updated successfully", Record = result });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Product>>> Delete(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product id not proper" });
            }
            var found = await unitOfWork.Products.GetByIdAsync(id.Value);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product not found" });
            }
            var result = await unitOfWork.Products.DeleteAsync(found);
            return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.OK, Message = "Product deleted successfully", Record = result });
        }

        //[HttpGet]
        //public async Task<ActionResult<ResponseModel<IEnumerable<Product>>>> GetAllAsync()
        //{
        //    var results = await repository.GetAllAsync();
        //    if (results == null || results.Count == 0)
        //    {
        //        return NotFound(new ResponseModel<IEnumerable<Product>>
        //        {
        //            ResponseCode = HttpStatusCode.NotFound,
        //            Message = "No records found"
        //        });
        //    }
        //    else
        //    {
        //        return Ok(new ResponseModel<IEnumerable<Product>>
        //        {
        //            ResponseCode = HttpStatusCode.Found,
        //            Message = "Records found",
        //            Record = results.ToList<Product>()
        //        });
        //    }
        //}
    }
}