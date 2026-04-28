using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByEmail(string email);
    }
}
