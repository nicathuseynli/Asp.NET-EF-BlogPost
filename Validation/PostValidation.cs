using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Dto;
using FluentValidation;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Validation;
public class PostValidation : AbstractValidator<PostDto>
{
    public PostValidation()
    {
        RuleFor(x => x.Title).Length(0, 30);
        RuleFor(x => x.Subtitle).Length(0, 30);
        RuleFor(x => x.Content).Length(0, 30);
        RuleFor(x => x.Description).Length(0, 30);
    }
}





