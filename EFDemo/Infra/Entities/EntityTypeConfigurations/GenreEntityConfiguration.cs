using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class GenreEntityConfiguration:
        BaseEntityTypeConfiguration<GenreEntity>
    {
        public override void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable(name: "Genres", schema: "ef");
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }

    }
    

}
