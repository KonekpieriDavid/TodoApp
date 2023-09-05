using FormUI.Model;

namespace FormUI.Data
{
    public interface IUserData
    {
        Task InsertRegister(Register register);
    }
}