using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ContentManagementSystem.Application.Abstraction;
using ContentManagementSystem.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Repositories.Author;
using ContentManagementSystem.Persistance.Repositories.Tag;
using ContentManagementSystem.Persistance.Repositories.Category;
using ContentManagementSystem.Application.Repositories.Category;
using ContentManagementSystem.Persistance.Repositories.Post;

namespace ContentManagementSystem.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerives(this IServiceCollection services)
        {
            services.AddDbContext<ContentManagementSystemDBContext>(options => options.UseNpgsql(Configuration.ConncetString));
            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            services.AddScoped<ITagReadRepository, TagReadRepository>();
            services.AddScoped<ITagWriteRepository, TagWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();

        }
    }
}
