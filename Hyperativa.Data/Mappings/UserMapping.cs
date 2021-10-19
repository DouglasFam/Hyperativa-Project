using Hyperativa.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
     public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(u => u.Access)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("HPRTV_Users");
        }
    }
}
