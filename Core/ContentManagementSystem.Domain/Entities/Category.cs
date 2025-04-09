using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities.Common;

namespace ContentManagementSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
