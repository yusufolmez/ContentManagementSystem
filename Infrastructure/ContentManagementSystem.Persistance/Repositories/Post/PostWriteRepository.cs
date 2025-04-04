using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Post
{
    public class PostWriteRepository : WriteRepository<Domain.Entities.Post>, IPostWriteRepository
    {
        public PostWriteRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
