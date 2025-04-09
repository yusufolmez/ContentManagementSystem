using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Tag
{
    public class VM_Create_Tag
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Guid> PostIds { get; set; } = new List<Guid>();
    }
}
