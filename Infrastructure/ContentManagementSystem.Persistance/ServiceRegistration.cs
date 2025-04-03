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

namespace ContentManagementSystem.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerives(this IServiceCollection services)
        {
            services.AddDbContext<ContentManagementSystemDBContext>(options => options.UseNpgsql(Configuration.ConncetString));
        }
    }
}
