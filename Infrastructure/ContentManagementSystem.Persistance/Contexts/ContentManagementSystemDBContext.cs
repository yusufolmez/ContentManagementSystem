﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities;
using ContentManagementSystem.Domain.Entities.Common;
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


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
                return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
