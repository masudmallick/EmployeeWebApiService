using EmployeeWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System.Net;

namespace EmployeeWebApiService.Controllers
{
    public class CustomerProductController : Controller
    {

        private readonly SQLServiceProvider _sqlServiceProvider;
        public CustomerProductController()
        {
            _sqlServiceProvider = new SQLServiceProvider();
        }

        [HttpGet]
        public JsonResult GetCustomerAndProducts()
        {
            List<GetCustomerAndProduct> getCustomerAndProducts = _sqlServiceProvider.GetCustomerAndProducts();
            return new JsonResult(getCustomerAndProducts);
        }

        [HttpGet]
        public JsonResult GetCustomer(string customerId)
        {
                GetCustomer getCustomerAndProduct = _sqlServiceProvider.GetCustomer(customerId);
                return new JsonResult(getCustomerAndProduct);
        }

        [HttpPost]
        public HttpResponseMessage Post(AddCustomerAndProduct addCustomerAndProduct)
        {
            _sqlServiceProvider.AddCustomerAndProduct(addCustomerAndProduct);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(int PId, DateTime saleDate)
        {
            _sqlServiceProvider.UpdateProductDate(PId, saleDate);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
