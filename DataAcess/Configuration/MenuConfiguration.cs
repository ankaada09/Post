using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(m => m.MenuName).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Link).IsRequired().HasMaxLength(50);

            builder.HasIndex(m => m.MenuName).IsUnique();
        }
    }
}
