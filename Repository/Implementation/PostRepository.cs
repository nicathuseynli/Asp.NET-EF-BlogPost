using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Context;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Abstraction;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Implementation;
public class PostRepository : EfRepository<Post, int>, IPostRepository
{
    private readonly BlogDbContext _appDbcontext;
    public PostRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _appDbcontext = dbContext;
    }
}
