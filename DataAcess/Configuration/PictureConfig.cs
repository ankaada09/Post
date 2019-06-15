using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Configuration
{
    class PictureConfig:IEntityTypeConfiguration<Picture>
    {
       
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.Name).IsRequired();
        }
    }
}
