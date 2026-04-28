using GameStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    private readonly IGameRepository _repo;
    public HomeController(IGameRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index()
    {
        return View(_repo.GetAll());
    }
}