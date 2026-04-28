using GameStore.Interfaces;
using GameStore.Models;
using GameStore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Game> GetAll()
    {
        return _context.Games.ToList();
    }

    public Game GetById(int id)
    {
        return _context.Games.Find(id);
    }

    public void Add(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
    }

    public void Update(Game game)
    {
        _context.Games.Update(game);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var game = _context.Games.Find(id);
        _context.Games.Remove(game);
        _context.SaveChanges();
    }
}