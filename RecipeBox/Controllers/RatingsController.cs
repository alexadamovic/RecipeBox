using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBox.Controllers
{
  public class RatingsController : Controller
  {
    private readonly RecipeBoxContext _db;

    public RatingsController(RecipeBoxContext db)
    {
      _db = db;
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Rating rating)
    {
      _db.Ratings.Add(rating);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}    