using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Dto;
using FluentValidation;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Validation;

    public class BlogValidation : AbstractValidator<BlogDto>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Description).Length(0, 25);
        }
    }

 