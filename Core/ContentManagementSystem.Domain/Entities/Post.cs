using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities.Common;

namespace ContentManagementSystem.Domain.Entities
{

    public class Post : BaseEntity
    {
        public enum Status
        {
            Draft,
            Published,
            Archived,
            Deleted
        }
        private Status _status;
        public string Title { get; set; } 
        public string Content { get; set; }
        public string Slug { get; set; }
        public Status CurrentStatus
        { 
            get { return _status; }
            set { _status = value; }
        }
        public int ViewCount { get; set; }
        public string PostPicturePath { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}

