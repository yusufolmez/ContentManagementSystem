using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.Persistance.Contexts
{
    public class ContentManagementSystemDBContext : DbContext
    {
        public ContentManagementSystemDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContentManagementSystem.Domain.Entities.File> Files { get; set; }
    }
}
