using GameStore.Models;
using System.Collections.Generic;

namespace GameStore.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetAll();
        Game GetById(int id);
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
    }
}