using CustomerDetails2.Models;

namespace CustomerDetails2.DBAccess
{
    public interface ISqlDataAccess
    {
        (IEnumerable<Status>, IEnumerable<OrdersData>) GetMultiple<U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase");
        Task<IEnumerable<T>> loadData<T, U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase");
        Task SaveData<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase");
    }
}