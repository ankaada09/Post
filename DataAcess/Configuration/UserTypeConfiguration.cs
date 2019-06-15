using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.Property(ut => ut.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(ut => ut.Type).IsRequired().HasMaxLength(20);

            builder.HasMany(c => c.Users)
              .WithOne(cp => cp.UserType)
              .HasForeignKey(cp => cp.UserTypeId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
