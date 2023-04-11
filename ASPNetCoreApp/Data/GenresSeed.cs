using ASPNetCoreApp.Models;

namespace ASPNetCoreApp.Data
{
    public static class GenresSeed
    {
        public static async Task SeedAsync(GamingPlatform context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Genres.Any())
                {
                    return;
                }

                var genres = new Genre[]
                {
                    new Genre{Name = "Экшен"},
                    new Genre{Name = "Приключение"},
                    new Genre{Name = "Стратегия"},
                    new Genre{Name = "Аркады"},
                    new Genre{Name = "Симулятор"}
                };
                foreach (Genre g in genres)
                {
                    context.Genres.Add(g);
                }

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
