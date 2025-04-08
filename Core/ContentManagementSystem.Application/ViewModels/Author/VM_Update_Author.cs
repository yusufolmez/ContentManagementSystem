using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Author
{
    public class VM_Update_Author
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicPath { get; set; }
    }
}
