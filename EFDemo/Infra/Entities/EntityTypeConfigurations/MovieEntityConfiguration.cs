using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    internal class MovieEntityConfiguration:
        BaseEntityTypeConfiguration<MovieEntity>

    {

        public override void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movies", schema: "ef");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);

            builder.Property(i=>i.ViewCount).HasDefaultValue(1);
            //one-to-many Directory
            builder.HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);


            //one-to-many Genre
            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.GenreId);

            //many to many Movie actor
            builder.HasMany(x => x.Actors)
                .WithMany(x => x.Movies)
                .UsingEntity(x=>x.ToTable("MovieActors"));

            //One-To-Many => MoviePhotos
            builder.HasMany(m => m.Photos)
                .WithOne(x => x.Movie)
                .HasForeignKey(m=>m.MovieId)
                .IsRequired(false);
            
            base.Configure(builder);
        }
    }
}
