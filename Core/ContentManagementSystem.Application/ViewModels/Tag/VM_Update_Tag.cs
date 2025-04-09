using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Tag
{
    public class VM_Update_Tag
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public List<string>? PostIds { get; set; }
    }
}
