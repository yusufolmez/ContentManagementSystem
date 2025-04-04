using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Author
{
    public class AuthorWriteRepository : WriteRepository<Domain.Entities.Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
