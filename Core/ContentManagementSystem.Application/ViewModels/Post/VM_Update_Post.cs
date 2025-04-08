using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Post
{
    public class VM_Update_Post
    {
        public string Id { get; set; }
        public string? CurrentStatus { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ViewCount { get; set; }
        public string? PostPicturePath { get; set; }
    }
}
