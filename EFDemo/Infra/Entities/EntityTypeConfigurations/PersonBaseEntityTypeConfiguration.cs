using EFDemo.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class PersonBaseEntityTypeConfiguration<TEntity> :
        BaseEntityTypeConfiguration<TEntity> where TEntity : PersonBaseEntity //BaseEntity den turemis tum classlari getirir
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.FirstName)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(e => e.LastName)
            .IsRequired(true)
       .HasMaxLength(100);

            base.Configure(builder);

        }
    }
}
