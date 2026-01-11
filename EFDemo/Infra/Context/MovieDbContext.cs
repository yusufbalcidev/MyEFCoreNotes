using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Infra.Entities;
using EFDemo.Infra.Entities.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;

namespace EFDemo.Infra.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            //veri tabani modelleri olusuturlurken neler olacagini burada belirleriz
            //biz belirlemez isek default olarak modeleller
            modelBuilder.HasDefaultSchema("ef");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration)
                .Assembly);
        }

    }
    public class DbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var connStr = "Server=.\\SQLEXPRESS;Database=MovieDb;Trusted_Connection=True;TrustServerCertificate=True;";
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();

            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.MigrationsHistoryTable("_MigrationsHistoryTable", schema: "ef");
                options.CommandTimeout(5_000);
                options.EnableRetryOnFailure(maxRetryCount: 5);
            });

            // Hazırlanan ayarları constructor'a göndererek nesneyi döndürün
            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
