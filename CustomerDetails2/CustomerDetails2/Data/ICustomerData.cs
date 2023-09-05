using CustomerDetails2.Models;

namespace CustomerDetails2.Data
{
    public interface ICustomerData
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task InsertCustomers(Customer customer);
        IResult InsertCustomersCvs(Customer customer);
    }
}