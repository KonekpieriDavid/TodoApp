using CustomersDetails.Models;

namespace CustomersDetails.Data
{
    public interface ICustomerData
    {
        Task InsertCustomers(Customer customer);
    }
}