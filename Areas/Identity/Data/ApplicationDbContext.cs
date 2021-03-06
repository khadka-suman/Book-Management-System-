using Book.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)

    {
    }
        public DbSet<Books> Books { get; set; }
   
         public DbSet<Category> Categories { get; set; }




    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }

    internal object GetBooksId(object books)
    {
        throw new NotImplementedException();
    }

    public DbSet<Category>? Category { get; set; }
}