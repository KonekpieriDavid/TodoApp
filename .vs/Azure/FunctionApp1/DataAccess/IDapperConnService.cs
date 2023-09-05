using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.FunctionApp1.DataAccess
{
    public interface IDapperConnService
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "SqlDatabase");
        Task <int> SaveData<T>(string storedProcedure, T parameters, string connectionId = "SqlDatabase");
    }
}