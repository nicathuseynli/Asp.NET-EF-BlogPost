using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Abstraction;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.UnitOfWork;
public interface IUnitOfWork
{
    public IRepository<Bloog, int> blogRepository { get; set; }
    public IRepository<Post, int> postRepository { get; set; }

    public Task Commit();
}
