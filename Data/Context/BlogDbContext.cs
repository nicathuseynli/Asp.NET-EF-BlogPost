using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Context;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options ):base(options)
    {

    }
    public DbSet<Bloog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
}
