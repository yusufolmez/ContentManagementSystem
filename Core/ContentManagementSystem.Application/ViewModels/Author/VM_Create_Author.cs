using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Author
{
    public class VM_Create_Author
    {
        public Guid Id { get; set; }  // Id otomatik olarak GUID tarafından atanacaktır
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePicPath { get; set; }
        public string Password { get; set; }
        public string CurrentRole { get; set; }  // Enum değerini string olarak alabiliriz
        public ICollection<Domain.Entities.Post> Posts { get; set; }

    }
}
