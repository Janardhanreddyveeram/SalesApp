using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SalesApp.Models;

namespace SalesApp.Services
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly IOptions<ApiUrls> apiUrls;
        private readonly ILogger<ProductHttpService> logger;
        private readonly string productApiUrl;

        public ProductHttpService(IOptions<ApiUrls> apiUrls, ILogger<ProductHttpService> logger)
        {
            this.apiUrls = apiUrls;
            this.logger = logger;
            productApiUrl = apiUrls.Value.ProductApiUrl;
        }

        public async Task<ApiResponseModel<ProductModel>> AddAsync(ProductModel productModel)
        {
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsJsonAsync<ProductModel>(productApiUrl, productModel);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> DeleteAsync(int id)
        {
            var url = $"{productApiUrl}/{id}";
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.DeleteAsync(url);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<ProductModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<ProductModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<ProductModel>>>(productApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> GetAsync(int id)
        {
            var url = $"{productApiUrl}/{id}";
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<ProductModel>>(url);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> UpdateAsync(ProductModel product)
        {
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsJsonAsync<ProductModel>(productApiUrl, product);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }
    }
}