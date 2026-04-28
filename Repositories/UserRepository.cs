using GameStore.Interfaces;
using GameStore.Models;
using GameStore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
}
