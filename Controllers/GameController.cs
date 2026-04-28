using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class GameController : Controller
{
    private readonly IGameRepository _repo;

    public GameController(IGameRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        return View(_repo.GetAll());
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Game game)
    {
        if (!ModelState.IsValid) return View(game);

        _repo.Add(game);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        return View(_repo.GetById(id));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Game game)
    {
        _repo.Update(game);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return RedirectToAction("Index");
    }
}