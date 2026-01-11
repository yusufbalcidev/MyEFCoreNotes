using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class MoviePhotoEntityConfigurtaion:BaseEntityTypeConfiguration<MoviePhotoEntity>
    {
        public override void Configure(EntityTypeBuilder<MoviePhotoEntity> builder)
        {
            builder.ToTable(name: "MoviePhotos", schema: "ef");

            builder.Property(i=>i.Url)
                .HasColumnName("Url")
                .IsRequired() 
                .HasMaxLength(1000);



            base.Configure(builder);
        }
    }
}
