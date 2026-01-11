using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class DirectorEntityConfiguration :
        PersonBaseEntityTypeConfiguration<DirectorEntity>
    {
        public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
            builder.ToTable(name: "Directors", schema: "ef");

            //TODO: Movies realtion
            //builder.HasMany(i => i.Movies)
            //    .WithOne(m => m.Director)
            //    .HasForeignKey(d => d.DirectorId);

            base.Configure(builder);
        }

    }
    

}
