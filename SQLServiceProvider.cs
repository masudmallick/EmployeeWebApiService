using EmployeeWebApiService.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeWebApiService
{
    public class SQLServiceProvider
    {
        private string _connectionString = "Data Source=ROG305; Initial Catalog=Customer; Persist Security Info=True;User ID=sa;Password=12345;";

        #region GetCustomerAndProducts
        public List<GetCustomerAndProduct> GetCustomerAndProducts()
        {
            List<GetCustomerAndProduct> getCustomerAndProducts = new List<GetCustomerAndProduct>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spGetCustomerAndProduct]", con) { CommandType = CommandType.StoredProcedure })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                if (dt != null)
                {
                    getCustomerAndProducts = (from row in dt.AsEnumerable()
                                              select new GetCustomerAndProduct
                                              {
                                                  ProductName = Convert.ToString(row["ProductName"]),
                                                  CustomerName = Convert.ToString(row["CustomerName"]),
                                                  SaleDate = Convert.ToDateTime(row["SaleDate"]),
                                                  ProductPrice = Convert.ToDecimal(row["ProductPrice"])
                                              }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getCustomerAndProducts;
        }
        #endregion

        #region AddCustomerAndProduct
        public int AddCustomerAndProduct(AddCustomerAndProduct addCustomerAndProduct)
        {
            int res = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spInsertCustomerAndProduct]", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = addCustomerAndProduct.CustomerId;
                        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = addCustomerAndProduct.CustomerName;
                        cmd.Parameters.Add("@GenderId", SqlDbType.Int).Value = addCustomerAndProduct.GenderId;
                        cmd.Parameters.Add("@ContactNumber", SqlDbType.VarChar).Value = addCustomerAndProduct.ContactNumber;
                        cmd.Parameters.Add("@ProductId", SqlDbType.VarChar).Value = addCustomerAndProduct.ProductId;
                        cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = addCustomerAndProduct.ProductName;
                        cmd.Parameters.Add("@ProductPrice", SqlDbType.Money).Value = addCustomerAndProduct.ProductPrice;

                        con.Open();
                        res = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        #region UpdateProductDate
        public int UpdateProductDate(int PId, DateTime updateDate)
        {
            int res = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spUpdateProductDate]", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@PId", SqlDbType.Int).Value = PId;
                        cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value = updateDate;

                        con.Open();
                        res = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        #region GetCustomer
        public GetCustomer GetCustomer(string CustomerId)
        {
            GetCustomer getCustomer = new GetCustomer();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spGetCustomer]", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = CustomerId;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                if (dt != null)
                {
                    getCustomer = (from row in dt.AsEnumerable()
                                   select new GetCustomer
                                   {
                                       PId = Convert.ToInt32(row["PId"]),
                                       CustomerName = Convert.ToString(row["CustomerName"]),
                                       ProductName = Convert.ToString(row["ProductName"]),
                                       ProductPrice = Convert.ToDecimal(row["ProductPrice"])
                                   }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getCustomer;
        }
        #endregion

    }
}
