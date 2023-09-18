namespace EmployeeWebApiService.Models
{
    public class GetCustomerAndProduct
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
