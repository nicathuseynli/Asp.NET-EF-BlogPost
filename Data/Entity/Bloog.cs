namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;

public class Bloog : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PostsCount { get; set; }

    /*Navigation*/
    public ICollection<Post>? Posts { get; set; }
}
