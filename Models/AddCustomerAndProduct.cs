namespace EmployeeWebApiService.Models
{
    public class AddCustomerAndProduct
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int GenderId { get; set; }
        public string ContactNumber { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
