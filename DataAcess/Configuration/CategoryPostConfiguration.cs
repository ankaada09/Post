using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    public class CategoryPostConfiguration : IEntityTypeConfiguration<CategoryPost>
    {
        public void Configure(EntityTypeBuilder<CategoryPost> builder)
        {
            builder.Property(cp => cp.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(cp => cp.NameCat).IsRequired().HasMaxLength(20);
            builder.HasIndex(cp => cp.NameCat).IsUnique();

            builder.HasMany(c => c.Posts)
            .WithOne(cp => cp.CategoryPost)
            .HasForeignKey(cp => cp.CategoryPostId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
