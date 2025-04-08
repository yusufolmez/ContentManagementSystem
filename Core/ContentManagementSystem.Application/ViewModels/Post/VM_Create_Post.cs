using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Application.ViewModels.Post
{
    public class VM_Create_Post
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string CurrentStatus { get; set; }
        public int ViewCount { get; set; } = 0;
        public string PostPicturePath { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();

    }
}
