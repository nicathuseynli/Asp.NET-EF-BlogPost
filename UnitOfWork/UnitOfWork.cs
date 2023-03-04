using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Context;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Abstraction;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Implementation;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Bloog, int> blogRepository { get; set; }
        public IRepository<Post, int> postRepository { get; set; }

        private readonly BlogDbContext _appDbContext;

        public UnitOfWork(BlogDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            blogRepository = new EfRepository<Bloog, int>(_appDbContext);
            postRepository = new PostRepository(_appDbContext);
        }
        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }

