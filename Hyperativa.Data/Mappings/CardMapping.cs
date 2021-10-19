using Hyperativa.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa.Data.Mappings
{
   public class CardMapping  : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Identifier)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(c => c.Lote)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.ToTable("HPRTV_Cards");
        }
    }
}
