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
      List<Recipe> model = new List<Recipe>();
      var RecipeList = _db.Recipes.ToList();
      string word = search;
      // string pattern = @"\b\w+\b";
      // Regex rgx = new Regex(pattern);
      // string sentence = search;

      // foreach (Match match in rgx.Matches(sentence))
      //    Console.WriteLine("Found '{0}' at position {1}", 
      //                      match.Value, match.Index);

      foreach (Recipe recipe in RecipeList)
      {
        if (recipe.Ingredients.Contains(word))
        {
          model.Add(recipe);
        }
      }
      return View(model);
      
      // var thisRecipe = _db.Recipes.FirstOrDefault(recipe => String.Contains(recipe.Ingredients, search));

      // List<Recipe> MatchingRecipes = _db.Recipes.FindAllThatMatch(recipe => String.Contains(recipe.Ingredients, search));
    }
  }
}

// mysql -uroot -pepicodus
// use <dbname>;
// select * from <tablename>;
// MAke change and want to see if it was written
// select * from <changed table>;

// https://mysite.com/Recipes/Edit?RecipeId=1&RatingId=5