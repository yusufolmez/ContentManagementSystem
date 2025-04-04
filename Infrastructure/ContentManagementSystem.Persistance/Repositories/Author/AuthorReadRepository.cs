using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Author
{
    public class AuthorReadRepository : ReadRepository<Domain.Entities.Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
