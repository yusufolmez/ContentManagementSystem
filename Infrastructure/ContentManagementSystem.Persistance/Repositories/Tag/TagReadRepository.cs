using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Tag
{
    public class TagReadRepository : ReadRepository<Domain.Entities.Tag>, ITagReadRepository
    {
        public TagReadRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
