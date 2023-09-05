using CustomerDetails2.Models;

namespace CustomerDetails2.Data
{
    public interface ICustomerData
    {
        IResult FilterDataCvs(IEnumerable<Customer> OrderDataFilter);
        Tuple<IEnumerable<Status>, IEnumerable<OrdersData>> GetAllOder(Filter orderfil);
        Task<IEnumerable<Customer>> GetAllOderdata(OrderDataFilter orderfil);
        Task InsertCustomers(OrdersData customer);
        IResult InsertCustomersCvs(OrdersData customer);
    }
}