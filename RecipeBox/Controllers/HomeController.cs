using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RecipeBox.Controllers
{
  public class HomeController : Controller
  {
    private readonly RecipeBoxContext _db;

    public HomeController(RecipeBoxContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      var model = _db;
      return View(model);
    }

    public ActionResult Search()
    {
      return View();
    }


    [HttpPost("/")]
    public ActionResult Search(string search)
    {
      string searchLower = search.ToLower();
      List<Recipe> model = _db.Recipes.Where(recipe => recipe.Ingredients.ToLower().Contains(searchLower)).ToList();
        return View(model);
    }

    public ActionResult DisplayRating()
    {
      List<Recipe> model = _db.Recipes.Where(recipe => recipe.RatingId >= 4).ToList();
      return View(model);
    }
  }
}

// mysql -uroot -pepicodus
// use <dbname>;
// select * from <tablename>;
// MAke change and want to see if it was written
// select * from <changed table>;

// https://mysite.com/Recipes/Edit?RecipeId=1&RatingId=5