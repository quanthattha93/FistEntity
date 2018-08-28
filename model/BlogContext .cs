using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fistEntity.model
{
        public class BlogContext : DbContext
        {
            public DbSet<Author> Author { get; set; }
            public DbSet<Post> Post { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=D:/học/fistEntity/blog.db");
            }
        }
    
}
