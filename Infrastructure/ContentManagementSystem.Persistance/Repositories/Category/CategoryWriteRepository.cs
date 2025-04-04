using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Repositories.Category;
using ContentManagementSystem.Persistance.Contexts;

namespace ContentManagementSystem.Persistance.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(ContentManagementSystemDBContext context) : base(context)
        {
        }
    }
}
