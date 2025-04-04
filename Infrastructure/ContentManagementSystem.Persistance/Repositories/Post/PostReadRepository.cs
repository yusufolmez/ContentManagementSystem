using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Post
{
    public class PostReadRepository : ReadRepository<Domain.Entities.Post>, IPostReadRepository
    {
        public PostReadRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
