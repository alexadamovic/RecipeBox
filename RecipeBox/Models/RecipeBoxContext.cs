using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public RecipeBoxContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}