using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Dto;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository.Abstraction;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.UnitOfWork;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Validation;
using FluentValidation;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IValidator<PostDto>, PostValidation>();
            services.AddScoped<IValidator<BlogDto>, BlogValidation>();
            return services;
        }
    }
}
