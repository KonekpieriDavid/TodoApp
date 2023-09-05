namespace CustomerDetails2.DBAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> loadData<T, U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase");
        Task SaveData<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase");
    }
}