using EFDemo.Infra.Context;
using EFDemo.Infra.DataGenerator;
using EFDemo.Infra.Entities;
using Microsoft.EntityFrameworkCore;

// 1. Ayarlar ve Bağlantı Yapılandırması
var connStr = "Server=.\\SQLEXPRESS;Database=MovieDb;Trusted_Connection=True;TrustServerCertificate=True;";
var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();

optionsBuilder.UseSqlServer(connStr, options =>
{
    options.MigrationsHistoryTable("_MigrationsHistoryTable", schema: "ef");
    options.CommandTimeout(5_000);
    options.EnableRetryOnFailure(maxRetryCount: 5);
});

optionsBuilder.LogTo(Log);

using var dbContext = new MovieDbContext(optionsBuilder.Options);

// 2. Uygulama Akışı
await EnsureMigrations();
await EnsureMovieData();

// Metot Çağrıları
await AddTestsAsync(); // Manuel veri ekleme testi
await GetActors();
PrintMovieNameWidthPhotoUrl(); // Fotoğrafları açıkça (explicit) yükleme

Console.WriteLine("\nİşlem tamamlandı. Kapatmak için bir tuşa basın...");
Console.ReadLine();

#region Yardımcı Metotlar (Local Functions)

// --- MANUEL VERİ EKLEME (ASYNC) ---
async Task AddTestsAsync()
{
    // Daha önce eklenip eklenmediğini kontrol etmek iyi bir pratiktir
    var isExist = await dbContext.Genres.AnyAsync(g => g.Name == "Drama");
    if (isExist) return;

    var genreEntity = new GenreEntity()
    {
        Id = Guid.NewGuid(),
        Name = "Drama",
        CreatedDate = DateTime.Now,
    };

    await dbContext.Genres.AddAsync(genreEntity);
    await dbContext.SaveChangesAsync();
    Console.WriteLine("Yeni Genre (Drama) başarıyla eklendi.");
}

// --- EXPLICIT LOADING ÖRNEĞİ ---
void PrintMovieNameWidthPhotoUrl()
{
    Console.WriteLine("\n--- Film Fotoğrafları (Explicit Loading) ---");

    // Filmi fotoğrafları olmadan çekiyoruz
    var movie = dbContext.Movies.FirstOrDefault();
    if (movie == null) return;

    // Koleksiyonu (Photos) sadece ihtiyaç duyduğumuzda yüklüyoruz
    dbContext.Entry(movie)
        .Collection(i => i.Photos)
        .Load();

    Console.WriteLine($"Film: {movie.Name}");
    if (!movie.Photos.Any()) Console.WriteLine("- Bu filme ait fotoğraf bulunamadı.");

    foreach (var x in movie.Photos)
    {
        Console.WriteLine($"- Url: {x.Url}");
    }
}

async Task GetActors()
{
    Console.WriteLine("\n--- Aktörler Sorgulanıyor ---");
    var actors = await dbContext.Actors
          .Where(x => x.FirstName.Contains("A"))
          .OrderBy(x => x.FirstName)
          .ToListAsync();

    foreach (var x in actors)
    {
        Console.WriteLine($"Aktör: {x.FirstName} {x.LastName}");
    }
}

async Task EnsureMigrations()
{
    var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any())
    {
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Migration'lar uygulandı.");
    }
}

async Task EnsureMovieData()
{
    if (await dbContext.Movies.AnyAsync()) return;

    var movies = DataGenerator.GenerateMovies(10);
    await dbContext.Movies.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
    Console.WriteLine("Otomatik veriler eklendi.");
}

void Log(string message)
{
    var color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"EfCore_Log: {message}");
    Console.ForegroundColor = color;
}

#endregion