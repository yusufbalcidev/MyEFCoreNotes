using EFDemo.Infra.DataGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class ActorEntityConfiguration : PersonBaseEntityTypeConfiguration<ActorEntity>
    {
        public override void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            builder.ToTable(name: "Actors");

            // Configure many-to-many relationship
            builder.HasMany(x => x.Movies)
                .WithMany(x => x.Actors)
                .UsingEntity(x => x.ToTable("ActorMovies"));

            // Seed actors - DÜZELTİLDİ: GenerateActor yerine DataGenerator
            builder.HasData(DataGenerator.DataGenerator.GenerateActors(20));

            base.Configure(builder);
        }
    }
}