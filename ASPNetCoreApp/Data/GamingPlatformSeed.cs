using ASPNetCoreApp.Models;

namespace ASPNetCoreApp.Data
{
    public static class GamingPlatformSeed
    {
        public static async Task SeedAsync(GamingPlatform context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Genres.Any() && context.Game.Any())
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

                var games = new Game[]
                {
                    new Game{Name = "Elden Ring",
                        GenreId = 1, 
                        Mode = "online", 
                        ReleaseDate = new DateTime(2022, 2, 25), 
                        Price = 3999, 
                        Developer = "FromSoftware Inc.", 
                        RegistrationDate = new DateTime(2022, 3, 10), 
                        ImageLink = "Elden Ring.jpg",
                        Rating = 5, 
                        NumberRatings = 20000,
                        Description = "Восстань, погасшая душа! Междуземье ждёт своего повелителя. Пусть благодать приведёт тебя к Кольцу Элден. Огромный мир с открытыми полями, множеством ситуаций и гигантскими подземельями, где сложные трёхмерные конструкции сочетаются воедино. Путешествуйте, преодолевайте смертельные опасности и радуйтесь успехам. Вы можете не только изменить внешность персонажа, но также комбинировать оружие, броню и предметы. Развивайте персонажа по своему вкусу. Наращивайте мышцы или постигайте таинства магии. Многослойная история, разбитая на фрагменты. Эпическая драма, в которой мысли персонажей пересекаются в Междуземье. Помимо многопользовательского режима, в котором вы напрямую подключаетесь к другим игрокам и путешествуете вместе, есть асинхронный сетевой режим, позволяющий ощутить присутствие других игроков."},

                    new Game{Name = "Vampire Survivors",
                        GenreId = 1,
                        Mode = "offline",
                        ReleaseDate = new DateTime(2022, 10, 20),
                        Price = 200,
                        Developer = "poncle",
                        RegistrationDate = new DateTime(2022, 10, 30),
                        ImageLink = "Vampire Survivors.jpg",
                        Rating = 5,
                        NumberRatings = 10000,
                        Description = "Vampire Survivors — казуальная игра в стиле готического хоррора с элементами упрощенного рогалика. Здесь каждое ваше решение может вызвать лавину последствий для орд монстров, с которыми вам предстоит столкнуться. Vampire Survivors — игра-выживалка на время с минималистичным геймплеем и элементами упрощенного рогалика. Ад опустел, а все демоны пришли сюда, и теперь уже некуда бежать или прятаться. Вам остается только выживать, сколько сможете, но однажды смерть обязательно положит конец и вашим потугам. Собирайте золото в каждый заход, чтобы купить улучшения и помочь следующему выжившему." },

                    new Game{Name = "Kingdom Rush - Tower Defense",
                        GenreId = 3,
                        Mode = "offline",
                        ReleaseDate = new DateTime(2014, 1, 6),
                        Price = 249,
                        Developer = "Ironhide Game Studio",
                        RegistrationDate = new DateTime(2020, 11, 6),
                        ImageLink = "Kingdom Rush - Tower Defense.jpg",
                        Rating = 4.5f,
                        NumberRatings = 500,
                        Description = "Приготовьтесь к увлекательному приключению, в котором вам с помощью башен и заклинаний предстоит защитить свое королевство от полчищ орков, троллей, злых колдунов и других мерзких тварей! Сражайтесь в лесах, горах и пустынях, меняя оборонительную стратегию под условия с помощью разных улучшений и способностей башен! Призывайте пламя на головы врагов, выводите в бой подкрепления, командуйте войсками, нанимайте эльфийских воинов и сражайтесь с легендарными чудищами, чтобы уберечь королевство от темных сил!" }
                };
                foreach (Game g in games)
                {
                    context.Game.Add(g);
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
