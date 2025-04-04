using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Tag
{
    public class TagWriteRepository : WriteRepository<Domain.Entities.Tag>, ITagWriteRepository
    {
        public TagWriteRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
