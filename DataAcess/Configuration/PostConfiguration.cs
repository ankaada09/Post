using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(p => p.Name).IsUnique();

           
            builder.Property(p => p.Text).IsRequired().HasMaxLength(200);

            builder.HasMany(p => p.Comments)
              .WithOne(cp => cp.Post)
              .HasForeignKey(cp => cp.PostId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Pictures).WithOne(cp => cp.Post).HasForeignKey(cp => cp.PostId).OnDelete(DeleteBehavior.Restrict);

            

        }
    }
}
