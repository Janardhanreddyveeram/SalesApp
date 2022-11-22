using SalesApp.Models;

namespace SalesApp.Services
{
    public interface IProductHttpService
    {
        Task<ApiResponseModel<ProductModel>> AddAsync(ProductModel productModel);
        Task<ApiResponseModel<ProductModel>> DeleteAsync(int id);
        Task<ApiResponseModel<IEnumerable<ProductModel>>> GetAllAsync();
        Task<ApiResponseModel<ProductModel>> GetAsync(int id);
        Task<ApiResponseModel<ProductModel>> UpdateAsync(ProductModel productModel);
    }
}
