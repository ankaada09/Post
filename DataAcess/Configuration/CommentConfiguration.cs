using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Comments).HasMaxLength(100).IsRequired();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c=>c.User)
             .WithMany(cp => cp.Comments)
             .HasForeignKey(cp => cp.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Post)
                .WithMany(cp => cp.Comments)
                .HasForeignKey(cp => cp.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}