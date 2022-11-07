using System.Net;

namespace SalesAppServices.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public T Record { get; set; }
    }
}
