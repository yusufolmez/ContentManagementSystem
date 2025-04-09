using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Category
{
    public class VM_Create_Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<Guid>? PostIds { get; set; } = new List<Guid>();
    }
}
