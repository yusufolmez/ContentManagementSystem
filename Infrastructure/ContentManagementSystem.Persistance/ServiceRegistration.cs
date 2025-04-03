using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ContentManagementSystem.Application.Abstraction;
using ContentManagementSystem.Persistance.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ContentManagementSystem.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerives(this IServiceCollection services)
        {
            services.AddSingleton<IPostService, PostService>();
        }
    }
}
